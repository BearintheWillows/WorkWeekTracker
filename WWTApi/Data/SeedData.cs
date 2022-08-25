namespace WWTApi.Data;

using DataModels.WorkModels;

public static class SeedData
{
	public static void EnsurePopulated(DataContext? context)
	{
		if ( !context.Breaks.Any())
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
			var run11 = new Run { Number = 68, LocationArea = "Norwich", DayOfWeek = DayOfWeek.Monday };
			var run12 = new Run { Number = 68, LocationArea = "Norwich", DayOfWeek = DayOfWeek.Tuesday };
			var run13 = new Run { Number = 68, LocationArea = "Norwich", DayOfWeek = DayOfWeek.Wednesday };
			var run14 = new Run { Number = 68, LocationArea = "Norwich", DayOfWeek = DayOfWeek.Thursday };
			var run15 = new Run { Number = 68, LocationArea = "Norwich", DayOfWeek = DayOfWeek.Friday };
			var run16 = new Run { Number = 68, LocationArea = "Norwich", DayOfWeek = DayOfWeek.Saturday };
			var run17 = new Run { Number = 68, LocationArea = "Norwich", DayOfWeek = DayOfWeek.Sunday };

			var run21 = new Run { Number = 14, LocationArea = "Northampton", DayOfWeek = DayOfWeek.Monday };
			var run22 = new Run { Number = 14, LocationArea = "Northampton", DayOfWeek = DayOfWeek.Tuesday };
			var run23 = new Run { Number = 14, LocationArea = "Northampton", DayOfWeek = DayOfWeek.Wednesday };
			var run24 = new Run { Number = 14, LocationArea = "Northampton", DayOfWeek = DayOfWeek.Thursday };
			var run25 = new Run { Number = 14, LocationArea = "Northampton", DayOfWeek = DayOfWeek.Friday };
			var run26 = new Run { Number = 14, LocationArea = "Northampton", DayOfWeek = DayOfWeek.Saturday };
			var run27 = new Run { Number = 14, LocationArea = "Northampton", DayOfWeek = DayOfWeek.Sunday };

			var run31 = new Run { Number = 65, LocationArea = "Corby", DayOfWeek = DayOfWeek.Monday };
			var run32 = new Run { Number = 65, LocationArea = "Corby", DayOfWeek = DayOfWeek.Tuesday };
			var run33 = new Run { Number = 65, LocationArea = "Corby", DayOfWeek = DayOfWeek.Wednesday };
			var run34 = new Run { Number = 65, LocationArea = "Corby", DayOfWeek = DayOfWeek.Thursday };
			var run35 = new Run { Number = 65, LocationArea = "Corby", DayOfWeek = DayOfWeek.Friday };
			var run36 = new Run { Number = 65, LocationArea = "Corby", DayOfWeek = DayOfWeek.Saturday };
			var run37 = new Run { Number = 65, LocationArea = "Corby", DayOfWeek = DayOfWeek.Sunday };

			var run41 = new Run { Number = 0, LocationArea = "Depot", DayOfWeek = DayOfWeek.Monday };
			var run42 = new Run { Number = 0, LocationArea = "Depot", DayOfWeek = DayOfWeek.Tuesday };
			var run43 = new Run { Number = 0, LocationArea = "Depot", DayOfWeek = DayOfWeek.Wednesday };
			var run44 = new Run { Number = 0, LocationArea = "Depot", DayOfWeek = DayOfWeek.Thursday };
			var run45 = new Run { Number = 0, LocationArea = "Depot", DayOfWeek = DayOfWeek.Friday };
			var run46 = new Run { Number = 0, LocationArea = "Depot", DayOfWeek = DayOfWeek.Saturday };
			var run47 = new Run { Number = 0, LocationArea = "Depot", DayOfWeek = DayOfWeek.Sunday };

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


			shift1.Runs.Add( run25 );
			shift2.Runs.Add( run26 );
			shift1.Breaks.Add( b1 );
			shift1.Breaks.Add( b2 );
			shift2.Breaks.Add( b3 );

			run23.Shops.Add( shop4 );
			run23.Shops.Add( shop5 );
			run23.Shops.Add( shop6 );
			run12.Shops.Add( shop1 );
			run12.Shops.Add( shop2 );
			run12.Shops.Add( shop3 );
			shift1.Runs.Add( run41 );

			context.Shifts.AddRange( shift1, shift2 );
			context.Runs.AddRange( run11, run12, run13, run14, run15, run16, run17, run21, run22, run23, run24, run25, run26, run27, run31, run32, run34, run33, run35, run36, run37);
			context.Shops.AddRange( shop1, shop2, shop3, shop4, shop5, shop6, shop7, shop8, shop9, shop10 );
			context.Breaks.AddRange( b1, b2, b3, b4, b5, b6 );
			context.SaveChanges();
		}
	}
}