using EFPlatzi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFPlatzi.Models;

var builder = WebApplication.CreateBuilder(args);

//aca agregamos la configuracion para conectarse a la db en memoria
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

//aca configuramos para conectar a sql server
//builder.Services.AddSqlServer<TareasContext>("Data Source=DESKTOP-C99SI6K;Initial Catalog=TareasDb;user id=sa;password=Panchito8513");
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));



var app = builder.Build();


app.MapGet("/", () => "Hello World! -- HOLA DESDE EL BACKEND");
//app.MapGet("/front", () => "Hello World! -- HOLA DESDE EL BACKEND");


//conexion a una db en memoria - probado en postman
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated(); //en vez de usar ensurecreated usar migrate

    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());

});

//creando un endpoint para modificar datos
app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{


    return Results.Ok(await dbContext.Tarea.Include(p => p.Categoria)
        .Where( p => p.PrioridadTarea == prioridad.baja).ToListAsync());
});

app.Run();
