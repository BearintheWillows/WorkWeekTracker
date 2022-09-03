using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using WWTApi.Data;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();

builder.Services.AddDbContext<DataContext>(opts => {
	opts.UseSqlServer(builder.Configuration["ConnectionStrings:WWTConnection"]);
	opts.EnableSensitiveDataLogging(true);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure the HTTP request pipeline

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors( x => x.AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials()
                   .WithOrigins( "http://localhost:4200" )
);

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();
app.MapDefaultControllerRoute();


var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();


SeedData.EnsurePopulated( context );

app.Run();