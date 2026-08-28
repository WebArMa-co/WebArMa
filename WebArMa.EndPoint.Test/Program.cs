using Microsoft.EntityFrameworkCore;
using WebArMa.Blogs.DependencyInjection;
using WebArMa.DependencyInjection;
using WebArMa.Identity.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();

builder.Services.AddWebArMa(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"), psg => psg.MigrationsAssembly(typeof(Program).Assembly)));
builder.Services.AddWebArMaIdentity();
builder.Services.AddWebArMaBlog();

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
