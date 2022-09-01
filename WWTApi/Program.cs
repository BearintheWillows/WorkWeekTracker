using Microsoft.EntityFrameworkCore;
using WWTApi.Data;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
builder.Services.AddDbContext<DataContext>(opts => {
	opts.UseSqlServer(builder.Configuration["ConnectionStrings:WWTConnection"]);
	opts.EnableSensitiveDataLogging(true);
});

builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// builder.Services.AddTransient<IRunRepository, RunRepository>();

var app = builder.Build();




app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllers();
app.MapDefaultControllerRoute();


var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();


SeedData.EnsurePopulated( context );

app.Run();