namespace WWTApi.Data;

using DataModels.Models;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options)
		: base( options )
	{ }
	
	public DbSet<Shift> Shifts { get; set; }
	public DbSet<Run>   Runs   { get; set; }
	public DbSet<Break> Breaks { get; set; }
	public DbSet<Shop>  Shops  { get; set; }

}