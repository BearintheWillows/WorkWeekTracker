using Microsoft.EntityFrameworkCore;
using WWTApi.Data;
using WWTApi.Data.Repository;
using WWTApi.Interfaces;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<DataContext>(opts => {
	opts.UseSqlServer(builder.Configuration["ConnectionStrings:WWTConnection"]);
	opts.EnableSensitiveDataLogging(true);
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IRunRepository, RunRepository>();

var app = builder.Build();




app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapDefaultControllerRoute();


app.MapFallbackToFile( "index.html" );

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
SeedData.EnsurePopulated( context );

app.Run();