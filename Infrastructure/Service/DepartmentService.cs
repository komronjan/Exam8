namespace Infrastructure.Service;
using Infrastructure.Context;
using Domain.Entitie;
using Microsoft.EntityFrameworkCore;

public class DepartmentService
{
    private readonly DataContext datacontext;

    public DepartmentService(DataContext _datacontext)
    {
        datacontext = _datacontext;
    }
    public async Task<List<Department>> GetDepartments()
    {
        return await datacontext.Departments.ToListAsync();
    }
    public async Task<Department> GetById(int id)
    {
        return await datacontext.Departments.FindAsync(id);
    }
    public async Task<Department> Update(Department department)
    {
        var find = await datacontext.Departments.FindAsync(department.Id);
        find.DepartmentName = department.DepartmentName;
        find.LocationId = department.LocationId;
        await datacontext.SaveChangesAsync();
        return department;
    }
    public async Task<bool> Delete(int id)
    {
        var find = await datacontext.Departments.FindAsync(id);
        datacontext.Departments.Remove(find);
        await datacontext.SaveChangesAsync();
        return true;
    }
    public async Task<Department> AddDepartment(Department department)
    {
        await datacontext.Departments.AddAsync(department);
        await datacontext.SaveChangesAsync();
        return department;
    }
}
