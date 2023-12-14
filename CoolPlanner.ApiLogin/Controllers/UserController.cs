using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Plantoufle.Model;
using Plantoufle.Repository;
using CoolPlanner.ApiLogin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IRepository<FamilyMember> _userRepository;

    public UsersController(IRepository<FamilyMember> userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FamilyMember>>> GetAllUsers()
    {
        var users = await _userRepository.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FamilyMember>> GetUserById(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<FamilyMember>> CreateUser(UserModel user)
    {
        FamilyMember userEntity = new FamilyMember()
        {
            //Id = user.Id,
            Email = user.Email,
            //Password = user.Password,
            //ConfirmPassword = user.ConfirmPassword,
            //Login = user.Name,
            //Name = user.Name,
            PhoneNumber = user.PhoneNumber,
            //Role = "Clodo",
            //Token = user.Token,
        };
        var createdUser = await _userRepository.AddAsync(userEntity);
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }

  
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, FamilyMember user)
    {
        //if (id != user.Id)
        //{
        //    return BadRequest();
        //}

        await _userRepository.UpdateAsync(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        await _userRepository.DeleteAsync(user);
        return NoContent();
    }
}
