using Microsoft.AspNetCore.Mvc;
using Plantoufle.Repository;

[Route("api/[controller]")]
[ApiController]
public class FamilyController : ControllerBase
{
    private readonly IRepository<Family> _familyRepository;

    public FamilyController(IRepository<Family> familyRepository)
    {
        _familyRepository = familyRepository ?? throw new ArgumentNullException(nameof(familyRepository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Family>>> GetAllFamily()
    {
        var family = await _familyRepository.GetAllAsync();
        return Ok(family);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Family>> GetFamilyById(int id)
    {
        var family = await _familyRepository.GetByIdAsync(id);
        if (family == null)
        {
            return NotFound();
        }
        return Ok(family);
    }

    [HttpPost]
    public async Task<ActionResult<Family>> CreateFamily(Family family)
    {
        //Family familyEntity = new()
        //{
        //    Email = family.Email,
        //    Name = family.Name,
        //    PhoneNumber = family.PhoneNumber,
        //    Pincode = family.Pincode,
        //    Family = new()
        //    {
        //        IdGroup = 1,
                
        //    },
        //    Id = familyEntity.Id,
        //    TaskFamily = 
        //};
        var createdFamily = await _familyRepository.AddAsync(family);
        return CreatedAtAction(nameof(GetFamilyById), new { id = createdFamily.Id }, createdFamily);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFamily(int id, Family family)
    {
        if (id != family.Id)
        {
            return BadRequest();
        }

        await _familyRepository.UpdateAsync(family);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFamily(int id)
    {
        var family = await _familyRepository.GetByIdAsync(id);
        if (family == null)
        {
            return NotFound();
        }

        await _familyRepository.DeleteAsync(family);
        return NoContent();
    }
}
