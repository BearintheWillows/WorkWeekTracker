namespace WWTApi.Controllers;

using Data;
using DataModels.WorkModels;
using DataModels.WorkModels.DTOs;
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
		{
			IQueryable<DailyRoute> plans;

			if ( day != null )
			{
				plans =  _dataContext.DailyRoutes
				                    .Where( x => x.RunId == id && x.DayOfWeek.Equals( day ) );
			} else
			{
				plans = _dataContext.DailyRoutes
				                    .Where( x => x.RunId == id );
			}

			return await plans.Select( x => new DailyRouteDto
					{
					RunId = x.RunId,
					Shops = plans.Include( x => x.Shop )
					             .Select( s => new ShopDto { ID = s.Shop.Id, Name = s.Shop.CompanyName, } ).ToList()
					}
			).FirstOrDefaultAsync();
		}
	}

	[HttpPost]
	public async Task Update([FromBody] Run run)
	{ 
		await _dataContext.Runs.AddAsync( run );
		
		for ( int i = 0; i < 7; i++ )
		{
			var dayIndex = i;
			_dataContext.DailyRoutes.Add( new DailyRoute { RunId = run.Id, DayOfWeek = ( DayOfWeek ) dayIndex } );

			++i;
		}

		await _dataContext.SaveChangesAsync();
	}

}