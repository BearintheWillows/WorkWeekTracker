namespace WWTApi.Controllers;

using Data;
using Data.WorkModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route( "api/[controller]" )]
public class DailyRouteController : ControllerBase
{
	private DataContext? _dataContext;

	public DailyRouteController(DataContext? dataContext)
	{
		_dataContext = dataContext;
	}

	[HttpGet]
	public async Task<List<DailyRoute>> GetAll()
	{
		return await _dataContext?.DailyRoutes.ToListAsync();
	}
	
	// [HttpGet( "{id}/{day?}" )]
	// public Task<DailyRouteDto> GetShopsByRunId(long id, DayOfWeek? day)
	// {
	// 	IQueryable<DailyRoute> plans;
	//
	// 	if ( day != null )
	// 	{
	// 		plans = _dataContext.DailyRoutes
	// 		                    .Where( x => x.RunId == id && x.DayOfWeek.Equals( day ) );
	// 	} else
	// 	{
	// 		plans = _dataContext.DailyRoutes
	// 		                    .Where( x => x.RunId == id );
	// 	}
	//
	// 	return plans.Select( x => new DailyRouteDto
	// 			{
	// 			RunId = x.RunId,
	// 			Shops = plans.Include( x => x.Shop )
	// 			             .Select( s => new ShopDto
	// 					              {
	// 					              ID = s.Shop.Id, Name = s.Shop.CompanyName,
	// 					              }
	// 			              ).ToList()
	// 			}
	// 	).FirstOrDefaultAsync();
	// }

	[HttpPost]
	public void AddRoute()
	{
		
	}
}