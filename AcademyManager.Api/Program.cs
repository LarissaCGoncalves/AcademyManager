using AcademyManager.Application.ClassGroup.Commands;
using AcademyManager.Application.ClassGroup.Validations;
using AcademyManager.Infra.Context;
using AcademyManager.Shared.Validations;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Banco de Dados (EF Core)
builder.Services.AddDbContext<AcademyManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// MediatR (para comandos e queries)
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateClassGroupCommand).Assembly));

// FluentValidation + Behavior de Validação
//builder.Services.AddValidatorsFromAssemblyContaining<CreateClassGroupCommandValidator>();
builder.Services.AddTransient<IValidator<CreateClassGroupCommand>, CreateClassGroupCommandValidator>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// Repositórios
//builder.Services.AddScoped<IUserRepository, UserRepository>();

// API Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Pipeline da aplicação
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();


