namespace Infrastructure.Service;
using Infrastructure.Context;
using Domain.Entitie;
using Microsoft.EntityFrameworkCore;

public class EmployeeService
{
    private readonly DataContext dataContext;

    public EmployeeService(DataContext _dataContext)
    {
        dataContext = _dataContext;
    }
    public async Task<List<Employee>> GetEmployees()
    {
        return await dataContext.Employees.ToListAsync();
    }
    public async Task<Employee> GetEmployeeById(int id)
    {
        return await dataContext.Employees.FindAsync(id);
    }
    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        employee.HairDate = DateTime.SpecifyKind(employee.HairDate, DateTimeKind.Utc);
        var find = await dataContext.Employees.FindAsync(employee.Id);
        find.FirstName = employee.FirstName;
        find.LastName = employee.LastName;
        find.EmailAddress = employee.EmailAddress;
        find.PhoneNumber = employee.PhoneNumber;
        find.HairDate = find.HairDate;
        find.JobId = employee.JobId;
        find.Salary = employee.Salary;
        find.Commission_pct = employee.Commission_pct;
        find.ManagerId = employee.ManagerId;
        find.Department = employee.Department;
        await dataContext.SaveChangesAsync();
        return employee;
    }
    public async Task<Employee> CreateEmployee(Employee employee)
    {
        employee.HairDate = DateTime.SpecifyKind(employee.HairDate, DateTimeKind.Utc);
        await dataContext.Employees.AddAsync(employee);
        await dataContext.SaveChangesAsync();
        return employee;
    }
    public async Task<bool> DeleteEmployee(int id)
    {
        var find = await dataContext.Employees.FindAsync(id);
        dataContext.Employees.Remove(find);
        await dataContext.SaveChangesAsync();
        return true;
    }

}
