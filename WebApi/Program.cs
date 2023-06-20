using webapi;
using WebApi.Middlewars;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//para poner sql server
builder.Services.AddSqlServer<TareasContext>("Server=DESKTOP-PTHQSOO\\SQLEXPRESS;database=TareasDb;Trusted_Connection=true;Trust Server Certificate=true;Integrated Security=False;Persist Security Info=false;User ID=sa;Password=12345");

/*
 "cnTareas": "Server=DESKTOP-PTHQSOO\\SQLEXPRESS;database=TareasDb;Trusted_Connection=true;Trust Server Certificate=true;Integrated Security=False;Persist Security Info=false;User ID=sa;Password=12345"
*/

//Inyectamos la dependencis

//a nivel de controlador o de clase 
//builder.Services.AddScop
//Se crea solo una instancia de la dependencia en todo el api
//builder.Services.AddSingleton
//para inyectar a nivel de constructor se usa este
builder.Services.AddScoped<IHelloWordService, HelloWordService>();
//se usa esta pero no es muy recomendable
//builder.Services.AddScoped(p=> new HelloWordService());
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareaService, TareaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

//Para usar swagger
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();



//app.UseTimeMiddleware();
    

app.MapControllers();

app.Run();
