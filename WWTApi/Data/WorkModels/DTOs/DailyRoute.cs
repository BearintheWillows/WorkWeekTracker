namespace WWTApi.Data.WorkModels;

using DTOs;
using Microsoft.EntityFrameworkCore;

public class DailyRoute
{
	/// <summary>
	/// Position on Route plan
	/// </summary>
	///
	public int Id { get; set; }

	public int StopId { get; set; }

	public int       RunId     { get; set; }
	public int?      ShopId    { get; set; }
	public DayOfWeek DayOfWeek { get; set; }

	public virtual Shop? Shop { get; set; }
	public virtual Run   Run  { get; set; }


	/// <summary>
	/// Creates a list of Dynamic objects
	/// For each item in the param -
	/// 1 - Create new Shop Dto
	/// 2 - Create new dynamic object using Run Id, Day of Week, StopId and (1) ShopDto
	/// Returns list of dynamic objects to represent the route.
	/// </summary>
	/// <param name="routePlan"></param>
	/// <returns>Returns a list of dynamic objects with a runId, day, stop id and shop</returns>
	public static List<dynamic> SetRouteDto(IQueryable<DailyRoute> routePlan)
	{
		List<dynamic> shopList = new List<dynamic>();
		foreach ( var item in routePlan.Include( x => x.Shop ) )
			if ( item.ShopId != null )
			{
				dynamic route = new
					{
					stopId = item.StopId,
					shop = new ShopDto
						{
						Id = item.Shop.Id,
						Name = item.Shop.CompanyName,
						Address1 = item.Shop.Address1,
						City = item.Shop.City,
						County = item.Shop.County,
						PostCode = item.Shop.PostCode
						}
					};
				shopList.Add( route );
			}

		return shopList;
	}


	/// <summary>
	/// Create a default route for eahc day of the week for the specified Run Id
	/// </summary>
	/// <param name="id"></param>
	/// <param name="dataContext"></param>
	/// <returns>Collection of 7 default routes</returns>
	public static async Task<bool> CreateBlankRoutes(int id, DataContext? dataContext)
	{
		int day = 0;
		var routeList = new List<DailyRoute>();

		for ( int i = day; i < 7; i++ )
		{
			var newDailyRoute = new DailyRoute
				{
				Run = await dataContext.Runs.FindAsync( id ),
				RunId = id,
				DayOfWeek = ( DayOfWeek ) day,
				StopId = 0,
				ShopId = null,
				Shop = null,
				};

			routeList.Add( newDailyRoute );

			day++;
		}

		foreach ( var item in routeList )
		{
			Console.WriteLine( item.RunId + item.DayOfWeek.ToString() + item.ShopId + item.Shop?.CompanyName );
		}

		if ( routeList.Count == 7 )
		{
			await dataContext.DailyRoutes.AddRangeAsync( routeList );

			await dataContext.SaveChangesAsync();
			return true;
		} else
		{
			return false;
		}
	}
}