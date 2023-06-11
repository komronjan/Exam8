using Infrastructure.Context;
using Domain.Entitie;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Service;
public class RegionService
{
    private readonly DataContext dataContext;
    public RegionService(DataContext _dataContext)
    {
        dataContext = _dataContext;
    }
    public async Task<List<Region>> GetRegions()
    {
        return await dataContext.Regions.ToListAsync();
    }
    public async Task<Region> GetById(int id)
    {
        return await dataContext.Regions.FindAsync(id);
    }
    public async Task<Region> CreateRegion(Region region)
    {
        await dataContext.Regions.AddAsync(region);
        await dataContext.SaveChangesAsync();
        return region;
    }
    public async Task<bool> DeleteRegion(int id)
    {
        var find = await dataContext.Regions.FindAsync(id);
        dataContext.Regions.Remove(find);
        await dataContext.SaveChangesAsync();
        return true;
    }
    public async Task<Region> UpdateRegion(Region region)
    {
        var find = await dataContext.Regions.FindAsync(region.Id);
        find.RegionName=region.RegionName;
        await dataContext.SaveChangesAsync();
        return region;
    }
}
