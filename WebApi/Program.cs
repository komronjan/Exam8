using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Service;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DataContext>(conf => conf.UseNpgsql(connection));
builder.Services.AddScoped<JobService>();
builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<JobHistoryService>();
builder.Services.AddScoped<JobGradeService>();
builder.Services.AddScoped<RegionService>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<DepartmentService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
