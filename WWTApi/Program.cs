using Microsoft.EntityFrameworkCore;
using WWTApi.Data;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(opts => {
	opts.UseSqlServer(builder.Configuration["ConnectionStrings:WWTConnection"]);
	opts.EnableSensitiveDataLogging(true);
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();
app.MapDefaultControllerRoute();

app.UseBlazorFrameworkFiles("/app");
app.MapFallbackToFile("/app/{*path:nonfile}", "/app/index.html");

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
SeedData.EnsurePopulated( context );

app.Run();