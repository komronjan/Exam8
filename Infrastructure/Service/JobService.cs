using Infrastructure.Context;
using Domain.Entitie;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Service;
public class JobService
{
    private readonly DataContext dataContext;

    public JobService(DataContext _dataContext)
    {
        dataContext = _dataContext;
    }
    public async Task<List<Job>> GetJobs()
    {
        return await dataContext.Jobs.ToListAsync();
    }
    public async Task<Job> GetById(int id)
    {
        return await dataContext.Jobs.FindAsync(id);
    }
    public async Task<Job> CreateJob(Job job)
    {
        await dataContext.Jobs.AddAsync(job);
        await dataContext.SaveChangesAsync();
        return job;
    }
    public async Task<bool> DeleteJob(int id)
    {
        var find = await dataContext.Jobs.FindAsync(id);
        dataContext.Jobs.Remove(find);
        await dataContext.SaveChangesAsync();
        return true;
    }
    public async Task<Job> UpdateJob(Job job)
    {
        var find = await dataContext.Jobs.FindAsync(job.Id);
        find.Title = job.Title;
        find.MaxSalary = job.MaxSalary;
        find.MinSalary = job.MinSalary;
        await dataContext.SaveChangesAsync();
        return job;
    }
}
