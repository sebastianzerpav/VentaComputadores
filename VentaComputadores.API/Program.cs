using VentaComputadores.API.Data;
using VentaComputadores.API.Services.Configuration;

var builder = WebApplication.CreateBuilder(args);

//Inyección de DbContext
DbContextConfiguration.Configuration(builder.Services, builder.Configuration);

// Add services to the container.
//Servicios de acceso a datos
ServicesConfiguration.Configuration(builder.Services);

builder.Services.AddControllers();
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
