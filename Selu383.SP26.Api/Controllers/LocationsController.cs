using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selu383.SP26.Api.Data;     // AppDbContext
using Selu383.SP26.Api.Dtos;     // LocationDto, CreateLocationDto, UpdateLocationDto
using Selu383.SP26.Api.Models;   // Location entity

namespace Selu383.SP26.Api.Controllers; // controller namespace

[ApiController]
[Route("api/[controller]")]
public sealed class LocationsController : ControllerBase
{
    private readonly AppDbContext _db;

    public LocationsController(AppDbContext db)
    {
        _db = db;
    }

    // GET /api/locations
    [HttpGet]
    public async Task<ActionResult<List<LocationDto>>> ListAll()
    {
        var locations = await _db.Locations
            .AsNoTracking()
            .Select(l => new LocationDto
            {
                Id = l.Id,
                Name = l.Name,
                Address = l.Address,
                TableCount = l.TableCount
            })
            .ToListAsync();

        return Ok(locations);
    }

    // GET /api/locations/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<LocationDto>> GetById(int id)
    {
        var location = await _db.Locations
            .AsNoTracking()
            .FirstOrDefaultAsync(l => l.Id == id);

        if (location == null)
            return NotFound();

        return Ok(new LocationDto
        {
            Id = location.Id,
            Name = location.Name,
            Address = location.Address,
            TableCount = location.TableCount
        });
    }

    // POST /api/locations
    [HttpPost]
    public async Task<ActionResult<LocationDto>> Create(CreateLocationDto dto)
    {
        var location = new Location
        {
            Name = dto.Name,
            Address = dto.Address,
            TableCount = dto.TableCount
        };

        _db.Locations.Add(location);
        await _db.SaveChangesAsync();

        var result = new LocationDto
        {
            Id = location.Id,
            Name = location.Name,
            Address = location.Address,
            TableCount = location.TableCount
        };

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    // PUT /api/locations/{id}
    [HttpPut("{id:int}")]
    public async Task<ActionResult<LocationDto>> Update(int id, UpdateLocationDto dto)
    {
        var location = await _db.Locations.FirstOrDefaultAsync(l => l.Id == id);

        if (location == null)
            return NotFound();

        location.Name = dto.Name;
        location.Address = dto.Address;
        location.TableCount = dto.TableCount;

        await _db.SaveChangesAsync();

        return Ok(new LocationDto
        {
            Id = location.Id,
            Name = location.Name,
            Address = location.Address,
            TableCount = location.TableCount
        });
    }

    // DELETE /api/locations/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var location = await _db.Locations.FirstOrDefaultAsync(l => l.Id == id);

        if (location == null)
            return NotFound();

        _db.Locations.Remove(location);
        await _db.SaveChangesAsync();

        return Ok();
    }
}
