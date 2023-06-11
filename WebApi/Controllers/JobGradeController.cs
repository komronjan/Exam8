using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
using Infrastructure.Service;
using Domain.Entitie;

[ApiController]
[Route("[controller]")]
public class JobGradeContoller : ControllerBase
{
    private readonly JobGradeService service;

    public JobGradeContoller(JobGradeService _service)
    {
        service = _service;
    }

    [HttpGet("Get")]
    public async Task<List<JobGrade>> GetJob()
    {
        return await service.GetJobGRades();
    }
    [HttpGet("GetById")]
    public async Task<JobGrade> GetById(int id)
    {
        return await service.GetById(id);
    }
    [HttpPost("Add")]
    public async Task<JobGrade> Add([FromForm]JobGrade jobGrade)
    {
        return await service.AddJobGrade(jobGrade);
    }
    [HttpPut("Update")]
    public async Task<JobGrade> Update([FromForm]JobGrade jobGrade)
    {
        return await service.Update(jobGrade);
    }
    [HttpDelete("Delete")]
    public async Task<bool> Delete(int id)
    {
        return await service.Delete(id);
    }
}
