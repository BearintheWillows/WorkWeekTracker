namespace WWTApi.Data;

using DataModels.WorkModels;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options)
		: base( options )
	{ }
	
	public DbSet<Run>   Runs   { get; set; }
	
	public DbSet<Shop>  Shops  { get; set; }

	public DbSet<DailyRoutePlan> DailyRoutePlans { get; set; }
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<DailyRoutePlan>()
		            .HasAlternateKey( p => new { p.ShopId, p.DayOfWeek } )
		            .HasName( "ShopUniqueKey" );
	}
}