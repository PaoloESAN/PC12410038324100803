using Microsoft.EntityFrameworkCore;
using PC12410038324100803.CORE.core.Interfaces;
using PC12410038324100803.CORE.core.Services;
using PC12410038324100803.CORE.infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var cnx = builder.Configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContext<PC12410038324100803.CORE.infrastructure.Data.DbContext>(options => options.UseSqlServer(cnx));

builder.Services.AddTransient<IOrdenservicioRepository, OrdenservicioRepository>();
builder.Services.AddTransient<IOrdenServicioService, OrdenServicioService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
