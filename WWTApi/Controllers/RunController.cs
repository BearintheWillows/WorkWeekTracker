namespace WWTApi.Controllers;

using Data;
using Data.WorkModels;
using Data.WorkModels.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route( "api/[controller]" )]
public class RunController : ControllerBase
{
	private DataContext? _dataContext;

	public RunController(DataContext? dataContext)
	{
		_dataContext = dataContext;
	}


	/// <summary>
	/// Returns all available Run Entities 
	/// </summary>
	/// <returns>List of Run Entities</returns>
	[HttpGet]
	public async Task<List<Run>?> GetAll()
	{
		return await _dataContext?.Runs.ToListAsync();
	}

	/// <summary>
	/// Get Runn by id param.
	/// </summary>
	/// <param name="id"></param>
	/// <returns>Returns JSON of a Run entity</returns>
	[HttpGet( "{id}" )]
	public async Task<Run>? GetRunById(long id)
	{
		return await _dataContext.Runs.SingleOrDefaultAsync( r => r.Id == id );
	}

	/// <summary>
	/// Retrieve A Route via Run Id and optional Day
	/// Optional DayOfWeek parameter available if filtering by specific day
	/// </summary>
	/// <param name="id"></param>
	/// <param name="day"></param>
	/// <returns>Returns JSON of ShopDto</returns>
	[HttpGet( "{id}/route/{day?}" )]
	public async Task<DailyRouteDto?> GetRoutePlanById(long id, DayOfWeek? day)
	{
		IQueryable<DailyRoute> plans;

		if ( day != null )
		{
			plans = _dataContext.DailyRoutes
			                    .Where( x => x.RunId == id && x.DayOfWeek.Equals( day ) );
		} else
		{
			plans = _dataContext.DailyRoutes
			                    .Where( x => x.RunId == id );
		}

		Task<DailyRouteDto?> route = plans.Include( r => r.Run ).Select( x => new DailyRouteDto
				{
				Id = x.Run.Id,
				Location = x.Run.LocationArea,
				DeliveryDay = day != null ? day.ToString().Normalize() : null,
				Shops = DailyRoute.SetRouteDto( plans )
				}
		).FirstOrDefaultAsync();

		return await route;
	}

	[HttpDelete( "{id}" )]
	public async Task<IActionResult> DeleteRun(int id)
	{
		if ( await Run.Delete( id, _dataContext ) )
		{
			return NoContent();
		}

		return NotFound();
	}

	[HttpPut( "{id}" )]
	public async Task<IActionResult> EditRun(int id, Run run)
	{
		if ( await Run.Edit( id, run, _dataContext ) )
		{
			return NoContent();
		}

		return NotFound();
	}

	[HttpPost]
	public async Task<IActionResult> PostRun(Run run)
	{
		if ( await Run.Create( run, _dataContext ) && await DailyRoute.CreateBlankRoutes( run.Id, _dataContext ))
		{
			return NoContent();
		}

		return BadRequest();
	}
}