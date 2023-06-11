using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
using Infrastructure.Service;
using Domain.Entitie;

[ApiController]
[Route("[controller]")]
public class JobContoller : ControllerBase
{
    private readonly JobService service;

    public JobContoller(JobService _service)
    {
        service = _service;
    }

    [HttpGet("Get")]
    public async Task<List<Job>> GetDepartments()
    {
        return await service.GetJobs();
    }
    [HttpGet("GetById")]
    public async Task<Job> GetById(int id)
    {
        return await service.GetById(id);
    }
    [HttpPost("Add")]
    public async Task<Job> Add([FromForm]Job job)
    {
        return await service.CreateJob(job);
    }

    [HttpPut("Update")]
    public async Task<Job> Update([FromForm]Job job)
    {
        return await service.UpdateJob(job);
    }
    [HttpDelete("Delete")]
    public async Task<bool> Delete(int id)
    {
        return await service.DeleteJob(id);
    }
}
