namespace WWTApi.Data;

using DataModels.WorkModels;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options)
		: base( options )
	{ }

	public DbSet<Run> Runs { get; set; }

	public DbSet<Shop> Shops { get; set; }

	public DbSet<DailyRoutePlan> DailyRoutePlans { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<DailyRoutePlan>()
		            .HasKey( x => new { x.RunId, x.ShopId, x.DayOfWeek } );
		modelBuilder.Entity<DailyRoutePlan>()
		            .HasIndex( x => new { x.ShopId, x.DayOfWeek, } )
		            .IsUnique();
	}
}