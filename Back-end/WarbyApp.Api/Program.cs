using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarbyApp.Core.Repositories;
using WarbyApp.Data;
using WarbyApp.Data.Repositories;
using WarbyApp.Service.Exceptions;
using WarbyApp.Service.Implementations;
using WarbyApp.Service.Interfaces;
using WarbyApp.Service.Profiles;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using WarbyApp.Api.Middlewares;
using WarbyApp.Service.Dtos.EyeglassesDtos;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState.Where(x => x.Value?.Errors.Count() > 0)
            .Select(x => new RestExceptionErrorItem(x.Key, x.Value?.Errors.First().ErrorMessage)).ToList();

        return new BadRequestObjectResult(new { message = (string)null, errors = errors });

    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationRulesToSwagger();
builder.Services.AddDbContext<WarbyAppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<EyeglassesCreateDtoValidator>();

builder.Services.AddScoped<IEyeglassesRepository, EyeglassesRepository>();
builder.Services.AddScoped<IEyeglassesService, EyeglassesService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
