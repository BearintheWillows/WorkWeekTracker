namespace WWTApi.Data.WorkModels;

using DTOs;
using Microsoft.EntityFrameworkCore;

public class DailyRoute
{
	/// <summary>
	/// Position on Route plan
	/// </summary>
	public int StopId { get; set; }

	public int        RunId     { get; set; }
	public int        ShopId    { get; set; }
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
	public static List<dynamic> SetRouteShops(IQueryable<DailyRoute> routePlan)
	{
		var shopList = new List<dynamic>();
		foreach ( var item in routePlan.Include( x => x.Shop ) )
		{
			var newShopDto = new ShopDto { Id = item.Shop.Id, Name = item.Shop.CompanyName };
			dynamic route = new { runId = item.RunId, day = item.DayOfWeek, stopId = item.StopId, shop = newShopDto };
		shopList.Add(route);
		}
		return shopList;
	}
}
