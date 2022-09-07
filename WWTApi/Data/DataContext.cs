namespace WWTApi.Data;

using Microsoft.EntityFrameworkCore;
using WorkModels;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options)
		: base( options )
	{ }

	public DbSet<Run> Runs { get; set; }

	public DbSet<Shop> Shops { get; set; }

	public DbSet<DailyRoute> DailyRoutes { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<DailyRoute>()
		            .HasKey( x => new { x.RunId, x.ShopId, x.DayOfWeek } );
		modelBuilder.Entity<DailyRoute>()
		            .HasIndex( x => new { x.ShopId, x.DayOfWeek, } )
		            .IsUnique();
		modelBuilder.Entity<DailyRoute>()
		            .HasIndex( x => new { x.StopId, x.DayOfWeek, x.RunId } )
		            .IsUnique();
	}
}