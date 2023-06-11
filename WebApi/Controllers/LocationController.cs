using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
using Infrastructure.Service;
using Domain.Entitie;

[ApiController]
[Route("[controller]")]
public class LocationController : ControllerBase
{
    private readonly LocationService service;

    public LocationController(LocationService _service)
    {
        service = _service;
    }

    [HttpGet("Get")]
    public async Task<List<Location>> GetDepartments()
    {
        return await service.GetLocations();
    }
    [HttpGet("GetById")]
    public async Task<Location> GetById(int id)
    {
        return await service.GetById(id);
    }
    [HttpPost("Add")]
    public async Task<Location> Add([FromForm]Location location)
    {
        return await service.CreateLocation(location);
    }
    [HttpPut("Update")]
    public async Task<Location> Update([FromForm]Location location)
    {
        return await service.UpdateLocation(location);
    }
    [HttpDelete("Delete")]
    public async Task<bool> Delete(int id)
    {
        return await service.DeleteLocation(id);
    }
}
