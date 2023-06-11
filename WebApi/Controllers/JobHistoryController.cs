using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
using Infrastructure.Service;
using Domain.Entitie;

[ApiController]
[Route("[controller]")]
public class JobhistoryContoller : ControllerBase
{
    private readonly JobHistoryService service;

    public JobhistoryContoller(JobHistoryService _service)
    {
        service = _service;
    }

    [HttpGet("Get")]
    public async Task<List<Jobhistory>> GetJobhistories()
    {
        return await service.GetJobHistory();
    }
    [HttpGet("GetById")]
    public async Task<Jobhistory> GetById(int id)
    {
        return await service.GetById(id);
    }
    [HttpPost("Add")]
    public async Task<Jobhistory> Add([FromForm]Jobhistory jobhistory)
    {
        return await service.CreateJobHistories(jobhistory);
    }
    [HttpPut("Update")]
    public async Task<Jobhistory> Update([FromForm]Jobhistory jobhistory)
    {
        return await service.UpdateJobHist(jobhistory);
    }
    [HttpDelete("Delete")]
    public async Task<bool> Delete(int id)
    {
        return await service.DeleteJobhistory(id);
    }
}
