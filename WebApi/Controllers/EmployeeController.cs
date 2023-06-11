using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
using Infrastructure.Service;
using Domain.Entitie;

[ApiController]
[Route("[controller]")]
public class EmployeeContoller : ControllerBase
{
    private readonly EmployeeService service;

    public EmployeeContoller(EmployeeService _service)
    {
        service = _service;
    }

    [HttpGet("Get")]
    public async Task<List<Employee>> Get()
    {
        return await service.GetEmployees();
    }
    [HttpGet("GetById")]
    public async Task<Employee> GetById(int id)
    {
        return await service.GetEmployeeById(id);
    }
    [HttpPost("Add")]
    public async Task<Employee> Add([FromForm]Employee employee)
    {
        return await service.CreateEmployee(employee);
    }
    [HttpPut("Update")]
    public async Task<Employee> Update([FromForm]Employee employee)
    {
        return await service.UpdateEmployee(employee);
    }
    [HttpDelete("Delete")]
    public async Task<bool> Delete(int id)
    {
        return await service.DeleteEmployee(id);
    }
}
