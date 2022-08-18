namespace WWTApi.Data;

using DataModels.Models;

public static class SeedData
{
	public static void EnsurePopulated(DataContext context)
	{
		if ( !context.Breaks.Any() )
		{
			var shop1 = new Shop
				{
				Name = "Shop 1", Address1 = "Address 1", City = "Northampton", PostCode = "NN1 1NN",
				};
			var shop2 = new Shop
				{
				Name = "Shop 2", Address1 = "Address 2", City = "Northampton", PostCode = "NN2 2NN",
				};
			var shop3 = new Shop
				{
				Name = "Shop 3", Address1 = "Address 3", City = "Northampton", PostCode = "NN3 3NN",
				};
			var shop4 = new Shop
				{
				Name = "Shop 4", Address1 = "Address 4", City = "Colchester", PostCode = "CO1 1CO",
				};
			var shop5 = new Shop
				{
				Name = "Shop 5", Address1 = "Address 5", City = "Colchester", PostCode = "C02 2CO",
				};
			var shop6 = new Shop
				{
				Name = "Shop 6", Address1 = "Address 6", City = "Colchester", PostCode = "C03 3CO",
				};
			var shop7 = new Shop
				{
				Name = "Shop 7", Address1 = "Address 7", City = "London", PostCode = "LN1 1LN",
				};
			var shop8 = new Shop
				{
				Name = "Shop 8", Address1 = "Address 8", City = "London", PostCode = "LN2 2LN",
				};
			var shop9 = new Shop
				{
				Name = "Shop 9", Address1 = "Address 9", City = "Crewe", PostCode = "CW1 1CW",
				};
			var shop10 = new Shop
				{
				Name = "Shop 10", Address1 = "Address 10", City = "Derby", PostCode = "DE1 1DE",
				};              
			var run1 = new Run { Number = 68, LocationArea = "London", DayOfWeek = DayOfWeek.Monday };
			var run3 = new Run { Number = 68, LocationArea = "London", DayOfWeek = DayOfWeek.Tuesday };
			var run4 = new Run { Number = 14, LocationArea = "Northants", DayOfWeek = DayOfWeek.Monday };
			var run5 = new Run { Number = 14, LocationArea = "Northants", DayOfWeek = DayOfWeek.Tuesday };
			var run6 = new Run { Number = 14, LocationArea = "Northants", DayOfWeek = DayOfWeek.Wednesday };
			var run7 = new Run { Number = 24, LocationArea = "Midlands", DayOfWeek = DayOfWeek.Monday };
			var run8 = new Run { Number = 25, LocationArea = "Essex", DayOfWeek = DayOfWeek.Monday };
			var run9 = new Run { Number = 25, LocationArea = "Essex", DayOfWeek = DayOfWeek.Saturday };
			var runSpare = new Run { LocationArea = "Depot", DayOfWeek = DayOfWeek.Monday };

			var b1 = new Break
				{
				StartTime = DateTime.Parse( "09:00" ), EndTime = DateTime.Parse( "10:00" ), Location = "A45 Lay-by",
				};
			var b2 = new Break
				{
				StartTime = DateTime.Parse( "10:00" ),
				EndTime = DateTime.Parse( "11:00" ),
				Location = "Outside Tesco",
				};
			var b3 = new Break
				{
				StartTime = DateTime.Parse( "11:00" ),
				EndTime = DateTime.Parse( "12:00" ),
				Location = "Outside OneStop",
				};
			var b4 = new Break
				{
				StartTime = DateTime.Parse( "12:00" ), EndTime = DateTime.Parse( "13:00" ), Location = "Nowhere",
				};
			var b5 = new Break
				{
				StartTime = DateTime.Parse( "13:00" ), EndTime = DateTime.Parse( "19:00" ), Location = "Lay-by",
				};
			var b6 = new Break
				{
				StartTime = DateTime.Parse( "19:00" ),
				EndTime = DateTime.Parse( "20:00" ),
				Location = "Outside Tesco",
				};

			var shift1 = new Shift
				{
				Date = DateTime.Parse( "16-08-2022" ),
				StartTime = DateTime.Parse( "09:00" ),
				EndTime = DateTime.Parse( "17:00" ),
				};
			var shift2 = new Shift
				{
				Date = DateTime.Parse( "15-08-2022" ),
				StartTime = DateTime.Parse( "09:00" ),
				EndTime = DateTime.Parse( "17:00" ),
				};

			
			shift1.Runs.Add( run5 );
			shift2.Runs.Add( run8 );
			shift1.Breaks.Add( b1 );
			shift1.Breaks.Add( b2 );
			shift2.Breaks.Add( b3 );
			
			run8.Shops.Add( shop4);
			run8.Shops.Add(shop5  );
			run8.Shops.Add( shop6 ); 
			run5.Shops.Add( shop1);
			run5.Shops.Add( shop2 );
			run5.Shops.Add( shop3 );
			shift1.Runs.Add( runSpare );
			
			context.Shifts.AddRange( shift1, shift2 );
			context.Runs.AddRange( run1, run3, run4, run5, run6, run7, run8, run9 );
			context.Shops.AddRange( shop1, shop2, shop3, shop4, shop5, shop6, shop7, shop8, shop9, shop10 );
			context.Breaks.AddRange( b1, b2, b3, b4, b5, b6 );
		context.SaveChanges();
		}
	}
}