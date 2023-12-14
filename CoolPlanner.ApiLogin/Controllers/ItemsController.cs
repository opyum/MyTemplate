using Microsoft.AspNetCore.Mvc;
using Plantoufle.Repository;
using CoolPlanner.ApiLogin;

[Route("api/[controller]")]
[ApiController]
public class MissionsController : ControllerBase
{
    private readonly IRepository<Mission> _missionRepository;

    public MissionsController(IRepository<Mission> missionRepository)
    {
        _missionRepository = missionRepository ?? throw new ArgumentNullException(nameof(missionRepository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Mission>>> GetAllMissions()
    {
        var missions = await _missionRepository.GetAllAsync();
        return Ok(missions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Mission>> GetMissionById(int id)
    {
        var mission = await _missionRepository.GetByIdAsync(id);
        if (mission == null)
        {
            return NotFound();
        }
        return Ok(mission);
    }

    [HttpPost]
    public async Task<ActionResult<Mission>> CreateMission(Mission mission)
    {
        var createdMission = await _missionRepository.AddAsync(mission);
        return CreatedAtAction(nameof(GetMissionById), new { id = createdMission.Id }, createdMission);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMission(int id, Mission mission)
    {
        if (id != mission.Id)
        {
            return BadRequest();
        }

        await _missionRepository.UpdateAsync(mission);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMission(int id)
    {
        var mission = await _missionRepository.GetByIdAsync(id);
        if (mission == null)
        {
            return NotFound();
        }

        await _missionRepository.DeleteAsync(mission);
        return NoContent();
    }
}
