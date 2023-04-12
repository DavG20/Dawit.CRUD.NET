

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleCRUD.Data;
using SampleCRUD.Models;

namespace SampleCRUD.Controllers;


[Route("api/[controller]")]
[ApiController]
public class TeamController : ControllerBase
{
    private static AppDbContext _context;

    public TeamController(AppDbContext dbContext)
    {
        _context = dbContext;
    }


    [HttpGet]

    public async Task<IActionResult> Get()
    {
        var teams = await _context.Team.ToListAsync();
        return Ok(teams);
    }


    [HttpGet("id")]


    public async Task<IActionResult> GetById(int id)
    {
        var team = await _context.Team.FirstOrDefaultAsync(t => t.ID == id);
        if (team == null)
        {
            return BadRequest("invalid id");
        }
        return Ok(team);
    }
    [HttpPost]

    public async Task<IActionResult> Post(Team team)
    {

        await _context.Team.AddAsync(team);

        await _context.SaveChangesAsync();

        return CreatedAtAction("GetByID", team.ID, team);


    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteById(int id)
    {
        var team = await _context.Team.FirstOrDefaultAsync(t => t.ID == id);

        if (team == null)
        {
            return BadRequest("no team found");
        }
        _context.Team.Remove(team);

        await _context.SaveChangesAsync();

        return NoContent();

    }



    [HttpPatch]

    public async Task<IActionResult> Patch(int id, string country)
    {

        var team = await _context.Team.FirstOrDefaultAsync(t => t.ID == id);

        if (team == null)
        {
            return BadRequest("invalid team  id");
        }

        team.Country = country;

        await _context.SaveChangesAsync();

        return Ok(team);




    }






}




