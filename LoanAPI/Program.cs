using LoanAPI.Context;
using LoanAPI.Models.Entities;
using LoanAPI.Models.IRepository;
using LoanAPI.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using LoanAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Cors
builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
                                    builder => builder.AllowAnyOrigin()
                                                      .AllowAnyHeader()
                                                      .AllowAnyMethod()));

// Add db context
builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSQLServer"));
});

// Automapper
builder.Services.AddAutoMapper(typeof(Program));

// Add Services
builder.Services.AddScoped<IRepository<Categories>, RepositoryAsync<Categories>>();
builder.Services.AddScoped<IRepository<Person>, RepositoryAsync<Person>>();
/*builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();*/ // Lo mismo con Loan, Person y Thing para DEPENDENCY INJECTION

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
