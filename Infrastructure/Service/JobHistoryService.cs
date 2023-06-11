using Infrastructure.Context;
using Domain.Entitie;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Service;
public class JobHistoryService
{
    private readonly DataContext dataContext;

    public JobHistoryService(DataContext _dataContext)
    {
        dataContext = _dataContext;
    }
    public async Task<List<Jobhistory>> GetJobHistory()
    {
        return await dataContext.Jobhistories.ToListAsync();
    }
    public async Task<Jobhistory> GetById(int id)
    {
        return await dataContext.Jobhistories.FindAsync(id);
    }
    public async Task<Jobhistory> CreateJobHistories(Jobhistory jobhistory)
    {
        jobhistory.EndDate=DateTime.SpecifyKind(jobhistory.EndDate,DateTimeKind.Utc);
        jobhistory.StartDate=DateTime.SpecifyKind(jobhistory.StartDate,DateTimeKind.Utc);
        await dataContext.Jobhistories.AddAsync(jobhistory);
        await dataContext.SaveChangesAsync();
        return jobhistory;
    }
    public async Task<bool> DeleteJobhistory(int id)
    {
        var find = await dataContext.Jobhistories.FindAsync(id);
        dataContext.Jobhistories.Remove(find);
        await dataContext.SaveChangesAsync();
        return true;
    }
    public async Task<Jobhistory> UpdateJobHist(Jobhistory jobhistory)
    {
        jobhistory.EndDate=DateTime.SpecifyKind(jobhistory.EndDate,DateTimeKind.Utc);
        jobhistory.StartDate=DateTime.SpecifyKind(jobhistory.StartDate,DateTimeKind.Utc);
        var find = await dataContext.Jobhistories.FindAsync(jobhistory.Id);
        find.StartDate = jobhistory.StartDate;
        find.EndDate = jobhistory.EndDate;
        find.JobId = jobhistory.JobId;
        find.DepartmentId = jobhistory.DepartmentId;
        await dataContext.SaveChangesAsync();
        return jobhistory;
    }
}
