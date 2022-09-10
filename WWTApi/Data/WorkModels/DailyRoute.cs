namespace WWTApi.Data.WorkModels;

using DTOs;
using Microsoft.EntityFrameworkCore;

public class DailyRoute
{
	/// <summary>
	/// Position on Route plan
	/// </summary>
	public int StopId { get; set; }

	public int       RunId     { get; set; }
	public int       ShopId    { get; set; }
	public DayOfWeek DayOfWeek { get; set; }

	public Shop Shop { get; set; }
	public Run  Run  { get; set; }


	/// <summary>
	/// Creates a list of Dynamic objects
	/// For each item in the param -
	/// 1 - Create new Shop Dto
	/// 2 - Create new dynamic object using Run Id, Day of Week, StopId and (1) ShopDto
	/// Returns list of dynamic objects to represent the route.
	/// </summary>
	/// <param name="routePlan"></param>
	/// <returns>Returns a list of dynamic objects with a runId, day, stop id and shop</returns>
	public static async Task<DailyRouteDto?> SetRouteDto(IQueryable<DailyRoute> routePlan)
	{
		var dailyRoute = await routePlan.FirstOrDefaultAsync().ConfigureAwait( false );
			var run = dailyRoute?.Run;
			List<dynamic> shopList = new List<dynamic>();

			foreach ( var item in routePlan.Include( x => x.Shop ) )
			{
				dynamic route = new { stopId = item.StopId, shop = new ShopDto
					{
					Id = item.Shop.Id,
					Name = item.Shop.CompanyName,
					Address1 = item.Shop.Address1,
					City = item.Shop.City,
					County = item.Shop.County,
					PostCode = item.Shop.PostCode
					}};
				shopList.Add( route );
			}

			var newRoute = new DailyRouteDto
				{
				RunId = run?.Id,
				Location = run?.LocationArea,
				DeliveryDay = dailyRoute.DayOfWeek.ToString(),
				Shops = shopList
				};

			return newRoute;
		}
}

