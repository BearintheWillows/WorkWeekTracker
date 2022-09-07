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


	public static List<Tuple<int, DayOfWeek, ShopDto>> SetRouteShops(IQueryable<DailyRoute> routePlan)
	{
		var shopList = new List<Tuple<int, DayOfWeek, ShopDto>>();
		foreach ( var item in routePlan.Include( x => x.Shop ) )
		{
			var newShopDto = new ShopDto {Id = item.Shop.Id, Name = item.Shop.CompanyName };
			var newTuple = Tuple.Create( item.StopId, item.DayOfWeek, newShopDto );
			shopList.Add( newTuple );
		}

		return shopList;
	}
}
