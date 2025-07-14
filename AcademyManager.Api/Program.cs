using AcademyManager.Application.ClassGroupUseCases.Commands;
using AcademyManager.Application.ClassGroupUseCases.Queries;
using AcademyManager.Application.ClassGroupUseCases.Validations;
using AcademyManager.Application.StudentUseCases.Commands;
using AcademyManager.Application.StudentUseCases.Queries;
using AcademyManager.Application.StudentUseCases.Validations;
using AcademyManager.Domain.Repositories;
using AcademyManager.Infra.Context;
using AcademyManager.Infra.Repositories;
using AcademyManager.Shared.Validations;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Banco de Dados (EF Core)
builder.Services.AddDbContext<AcademyManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Logs
builder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();
builder.Services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

// MediatR (para comandos e queries)
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateClassGroupCommand).Assembly));

// FluentValidation + Behavior de Validação
builder.Services.AddTransient<IValidator<CreateClassGroupCommand>, CreateClassGroupCommandValidator>();
builder.Services.AddTransient<IValidator<UpdateClassGroupCommand>, UpdateClassGroupCommandValidator>();
builder.Services.AddTransient<IValidator<RemoveClassGroupCommand>, RemoveClassGroupCommandValidator>();
builder.Services.AddTransient<IValidator<CreateStudentCommand>, CreateStudentCommandValidator>();
builder.Services.AddTransient<IValidator<UpdateStudentCommand>, UpdateStudentCommandValidator>();
builder.Services.AddTransient<IValidator<RemoveStudentCommand>, RemoveStudentCommandValidator>();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// Repositórios
builder.Services.AddScoped<IClassGroupRepository, ClassGroupRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

// Queries
builder.Services.AddScoped<IClassGroupQueries, ClassGroupQueries>();
builder.Services.AddScoped<IStudentQueries, StudentQueries>();

// API Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});
builder.Services.AddLogging();

// Pipeline da aplicação
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();


