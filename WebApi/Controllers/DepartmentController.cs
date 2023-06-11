using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
using Infrastructure.Service;
using Domain.Entitie;

[ApiController]
[Route("[controller]")]
public class DepartmentContoller : ControllerBase
{
    private readonly DepartmentService service;

    public DepartmentContoller(DepartmentService _service)
    {
        service = _service;
    }

    [HttpGet("GetDepartment")]
    public async Task<List<Department>> GetDepartments()
    {
        return await service.GetDepartments();
    }
    [HttpGet("GetById")]
    public async Task<Department> GetById(int id)
    {
        return await service.GetById(id);
    }
    [HttpPost("Add")]
    public async Task<Department> Add([FromForm]Department department)
    {
        return await service.AddDepartment(department);
    }
    [HttpPut("Update")]
    public async Task<Department> Update([FromForm]Department department)
    {
        return await service.Update(department);
    }
    [HttpDelete("Delete")]
    public async Task<bool> Delete(int id)
    {
        return await service.Delete(id);
    }
}
