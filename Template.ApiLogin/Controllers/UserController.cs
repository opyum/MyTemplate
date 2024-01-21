using Microsoft.AspNetCore.Mvc;
using Plantoufle.Repository;
using TemplateX.CrossCutting;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IRepository<Sample> _userRepository;

    public UsersController(IRepository<Sample> userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sample>>> GetAllUsers()
    {
        var users = await _userRepository.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Sample>> GetUserById(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }


    [HttpPost]
    public async Task<ActionResult<UserRecordModel>> CreateUser(UserRecordModel user)
    {
        Sample familyMember = new Sample()
        {
            Email = user.Email,
            Id = user.Id,
            Name = user.Name,
            PhoneNumber = user.PhoneNumber,
            Role = user.Role,
        };
        var createdUser = await _userRepository.AddAsync(familyMember);
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }

  
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, Sample user)
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
