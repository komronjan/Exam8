using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
using Infrastructure.Service;
using Domain.Entitie;

[ApiController]
[Route("[controller]")]
public class RegionController : ControllerBase
{
    private readonly RegionService service;

    public RegionController(RegionService _service)
    {
        service = _service;
    }

    [HttpGet("Get")]
    public async Task<List<Region>> Get()
    {
        return await service.GetRegions();
    }
    [HttpGet("GetById")]
    public async Task<Region> GetById(int id)
    {
        return await service.GetById(id);
    }
    [HttpPost("Add")]
    public async Task<Region> Add([FromForm]Region region)
    {
        return await service.CreateRegion(region);
    }
    [HttpPut("Update")]
    public async Task<Region> Update([FromForm]Region region)
    {
        return await service.UpdateRegion(region);
    }
    [HttpDelete("Delete")]
    public async Task<bool> Delete(int id)
    {
        return await service.DeleteRegion(id);
    }
}
