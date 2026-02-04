using Microsoft.AspNetCore.Mvc;
using Selu383.SP26.Api.Data;
using Selu383.SP26.Api.Dtos;
using Selu383.SP26.Api.Entities;

namespace Selu383.SP26.Api.Controllers;

[Route("api/locations")]
[ApiController]
public class LocationsController : ControllerBase
{
    private readonly DataContext _context;

    public LocationsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<LocationDto>> GetAll()
    {
        return Ok(_context.Locations.Select(x => new LocationDto
        {
            Id = x.Id,
            Name = x.Name,
            Address = x.Address,
            TableCount = x.TableCount
        }).ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<LocationDto> GetById(int id)
    {
        var location = _context.Locations.FirstOrDefault(x => x.Id == id);
        if (location == null) return NotFound();

        return Ok(new LocationDto
        {
            Id = location.Id,
            Name = location.Name,
            Address = location.Address,
            TableCount = location.TableCount
        });
    }

    [HttpPost]
    public ActionResult<LocationDto> Create(LocationDto dto)
    {
        var location = new Location
        {
            Name = dto.Name,
            Address = dto.Address,
            TableCount = dto.TableCount
        };

        _context.Locations.Add(location);
        _context.SaveChanges();

        dto.Id = location.Id;
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    public ActionResult<LocationDto> Update(int id, LocationDto dto)
    {
        var location = _context.Locations.FirstOrDefault(x => x.Id == id);
        if (location == null) return NotFound();

        location.Name = dto.Name;
        location.Address = dto.Address;
        location.TableCount = dto.TableCount;

        _context.SaveChanges();

        dto.Id = location.Id;
        return Ok(dto);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var location = _context.Locations.FirstOrDefault(x => x.Id == id);
        if (location == null) return NotFound();

        _context.Locations.Remove(location);
        _context.SaveChanges();

        return Ok();
    }
}