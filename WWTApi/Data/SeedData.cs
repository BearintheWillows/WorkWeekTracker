namespace WWTApi.Data;

using Microsoft.EntityFrameworkCore;
using WorkModels;

public class SeedData
{
	public static void EnsurePopulated(DataContext? context)
	{
		if ( !context.DailyRoutes.Any() )
		{
			var runs = new List<Run>
				{
				new() { Id = 68, Location = "Norwhich" },
				new() { Id = 14, Location = "Northampton" },
				new() { Id = 6, Location = "Ipswich" },
				new() { Id = 104, Location = "Essex" },
				};
			runs.ForEach( r => context?.Runs.Add( r ) );
			context?.SaveChanges();


			var shops = new List<Shop>
				{
				new() { CompanyName = "Tesco", Address1 = "3 Sample Road", City = "Northampton", PostCode = "NN28NN" },
				new()
					{
					CompanyName = "One Stop", Address1 = "3 Sample Road", City = "Northampton", PostCode = "NN28NB"
					},
				new() { CompanyName = "Tesco", Address1 = "3 Sample Road", City = "Northampton", PostCode = "NN28NL" },
				new()
					{
					CompanyName = "One Stop", Address1 = "3 Sample Road", City = "Billericay", PostCode = "B125XZ"
					},
				new() { CompanyName = "Dobbies", Address1 = "3 Sample Road", City = "Billericay", PostCode = "B125XY" },
				new()
					{
					CompanyName = "One Stop", Address1 = "3 Sample Road", City = "Billericay", PostCode = "B125XX"
					},
				new()
					{
					CompanyName = "Sainsburys", Address1 = "3 Sample Road", City = "Norwhich", PostCode = "NR1 2AS"
					},
				new()
					{
					CompanyName = "Sainsburys", Address1 = "3 Sample Road", City = "Norwhich", PostCode = "NR1 2LP"
					},
				new()
					{
					CompanyName = "Sainsburys", Address1 = "3 Sample Road", City = "Norwhich", PostCode = "NR1 2DS"
					},
				new() { CompanyName = "Dobbies", Address1 = "3 Sample Road", City = "Ipswich", PostCode = "IP2 8NJ" },
				new()
					{
					CompanyName = "Sainsburys", Address1 = "3 Sample Road", City = "Ipswich", PostCode = "IP2 8NA"
					},
				new() { CompanyName = "Dobbies", Address1 = "3 Sample Road", City = "Ipswich", PostCode = "IP2 8ND" },
				};

			shops.ForEach( s => context?.Shops.Add( s ) );
			context?.SaveChanges();

			var dailyRoutePlans = new List<DailyRoute>
				{
				new() { RunId = 68, ShopId = 2, StopId = 1, DayOfWeek = DayOfWeek.Monday },
				new() { RunId = 68, ShopId = 4, StopId = 2, DayOfWeek = DayOfWeek.Monday },
				new() { RunId = 14, ShopId = 3, StopId = 1, DayOfWeek = DayOfWeek.Monday },
				new() { RunId = 68, ShopId = 3, StopId = 2, DayOfWeek = DayOfWeek.Tuesday },
				};

			dailyRoutePlans.ForEach( d => context?.DailyRoutes.Add( d ) );
			context?.SaveChanges();
		}
	}
}