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
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WarbyApp.Api.Services;
using AutoMapper;
using Swashbuckle.AspNetCore.SwaggerGen;

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




//builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
//{
//    opt.Password.RequireNonAlphanumeric = false;
//    opt.Password.RequiredLength = 8;
//}).AddDefaultTokenProviders().AddEntityFrameworkStores<WarbyAppDbContext>();

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "Ahop App API",
//        Version = "v1",
//        Description = "An API to perform e-commerse operations",
//    });
//    // Set the comments path for the Swagger JSON and UI.
//    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
//    c.IncludeXmlComments(xmlPath);

//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        In = ParameterLocation.Header,
//        Description = "Please enter token",
//        Name = "Authorization",
//        Type = SecuritySchemeType.Http,
//        BearerFormat = "JWT",
//        Scheme = "bearer"
//    });
//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type=ReferenceType.SecurityScheme,
//                    Id="Bearer"
//                }
//            },
//            new string[]{}
//        }
//    });
//});





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "WarbyShop App API",
        Version = "v1",
        Description = "An API to perform e-commerse operations",
    });
    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});


builder.Services.AddFluentValidationRulesToSwagger();
builder.Services.AddDbContext<WarbyAppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<EyeglassesCreateDtoValidator>();

builder.Services.AddScoped<IEyeglassesRepository, EyeglassesRepository>();
builder.Services.AddScoped<IEyeglassesService, EyeglassesService>();
builder.Services.AddScoped<ISunglassesRepository, SunglassesRepository>();
builder.Services.AddScoped<ISunglassesService, SunglassesService>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IColorService, ColorService>();
//builder.Services.AddScoped<JwtService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped(provider =>
    new MapperConfiguration(opt =>
    {
        opt.AddProfile(new MappingProfile(provider.GetService<IHttpContextAccessor>()));
    }).CreateMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
