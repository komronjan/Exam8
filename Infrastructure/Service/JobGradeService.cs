namespace Infrastructure.Service;
using Infrastructure.Context;
using Domain.Entitie;
using Microsoft.EntityFrameworkCore;

public class JobGradeService
{
    private readonly DataContext datacontext;

    public JobGradeService(DataContext _datacontext)
    {
        datacontext = _datacontext;
    }
    public async Task<List<JobGrade>> GetJobGRades()
    {
        return await datacontext.JobGrades.ToListAsync();
    }
    public async Task<JobGrade> GetById(int id)
    {
        return await datacontext.JobGrades.FindAsync(id);
    }
    public async Task<JobGrade> Update(JobGrade jobGrade)
    {
        var find = await datacontext.JobGrades.FindAsync(jobGrade.GradeLelel);
        find.HighesttSal = jobGrade.HighesttSal;
        find.LowestSal = jobGrade.LowestSal;
        await datacontext.SaveChangesAsync();
        return jobGrade;
    }
    public async Task<bool> Delete(int id)
    {
        var find = await datacontext.JobGrades.FindAsync(id);
        datacontext.JobGrades.Remove(find);
        await datacontext.SaveChangesAsync();
        return true;
    }
    public async Task<JobGrade> AddJobGrade(JobGrade jobGrade)
    {
        await datacontext.JobGrades.AddAsync(jobGrade);
        await datacontext.SaveChangesAsync();
        return jobGrade;
    }
}
