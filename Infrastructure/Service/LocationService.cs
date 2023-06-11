using Infrastructure.Context;
using Domain.Entitie;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Service;
public class LocationService
{
    private readonly DataContext dataContext;
    public LocationService(DataContext _dataContext)
    {
        dataContext = _dataContext;
    }
    public async Task<List<Location>> GetLocations()
    {
        return await dataContext.Locations.ToListAsync();
    }
    public async Task<Location> GetById(int id)
    {
        return await dataContext.Locations.FindAsync(id);
    }
    public async Task<Location> CreateLocation(Location location)
    {
        await dataContext.Locations.AddAsync(location);
        await dataContext.SaveChangesAsync();
        return location;
    }
    public async Task<bool> DeleteLocation(int id)
    {
        var find = await dataContext.Locations.FindAsync(id);
        dataContext.Locations.Remove(find);
        await dataContext.SaveChangesAsync();
        return true;
    }
    public async Task<Location> UpdateLocation(Location location)
    {
        var find = await dataContext.Locations.FindAsync(location.Id);
        find.StreetAddress = location.StreetAddress;
        find.PostalCode = location.PostalCode;
        find.City = location.City;
        find.StateProvince = location.StateProvince;
        find.CountryId = location.CountryId;
        await dataContext.SaveChangesAsync();
        return location;
    }
}
