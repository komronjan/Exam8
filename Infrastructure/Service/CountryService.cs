namespace Infrastructure.Service;
using Domain.Entitie;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
public class CountryService
{
    private readonly DataContext dataContext;

    public CountryService(DataContext _dataContext)
    {
        dataContext = _dataContext;
    }
    public async Task<List<Country>> GetCountries()
    {
        return await dataContext.Countries.ToListAsync();
    }
    public async Task<Country> GetById(int id)
    {
        return await dataContext.Countries.FindAsync(id);
    }
    public async Task<Country> UpdateCountry(Country country)
    {
        var find = await dataContext.Countries.FindAsync(country.Id);
        find.CountryName = country.CountryName;
        find.RegionId = country.RegionId;
        await dataContext.SaveChangesAsync();
        return country;
    }
    public async Task<bool> DeleteCountry(int id)
    {
        var find = await dataContext.Countries.FindAsync(id);
        dataContext.Countries.Remove(find);
        await dataContext.SaveChangesAsync();
        return true;
    }
    public async Task<Country> CreateCountry(Country country)
    {
        await dataContext.Countries.AddAsync(country);
        await dataContext.SaveChangesAsync();
        return country;
    }
}
