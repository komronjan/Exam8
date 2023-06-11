using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
using Infrastructure.Service;
using Domain.Entitie;

[ApiController]
[Route("[controller]")]
public class CountryController : ControllerBase
{
    private readonly CountryService service;

    public CountryController(CountryService _service)
    {
        service = _service;
    }

    [HttpGet("GetCountries")]
    public async Task<List<Country>> GetCountries()
    {
        return await service.GetCountries();
    }
    [HttpGet("GetCountriesById")]
    public async Task<Country> GetCountriesById(int id)
    {
        return await service.GetById(id);
    }
    [HttpPost("AddCountries")]
    public async Task<Country> AddCountries([FromForm]Country country)
    {
        return await service.CreateCountry(country);
    }
    [HttpPut("UpdateCountries")]
    public async Task<Country> UpdateCountries([FromForm]Country country)
    {
        return await service.UpdateCountry(country);
    }
     [HttpDelete("DeleteCountries")]
    public async Task<bool> DeleteCountries(int id)
    {
        return await service.DeleteCountry(id);
    }
}
