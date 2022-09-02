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

	//GET
	//
	/// <summary>
	/// Returns all available Run Entities 
	/// </summary>
	/// <returns>List of Run Entities</returns>
	[HttpGet]
	public async Task<List<Run>?> GetAll()
	{
		return await _dataContext?.Runs.ToListAsync();
	}

	//GET BY ID
	//
	/// <summary>
	/// Get Run on it's own by id param.
	/// </summary>
	/// <param name="id"></param>
	/// <returns>Returns JSON of a Run entity</returns>
	[HttpGet( "{id}" )]
	public async Task<Run>? GetRunById(long id)
	{
		return await _dataContext.Runs.SingleOrDefaultAsync( r => r.Id == id );
	}

	//GET SHOPS OF RUN BY ID
	//
	/// <summary>
	/// Retrieve shops for a specific run by id
	/// Optional DayOfWeek parameter available if filtering by specific day
	/// </summary>
	/// <param name="id"></param>
	/// <param name="day"></param>
	/// <returns>Returns JSON of ShopDto</returns>
	[HttpGet( "{id}/shops/{day?}" )]
	public List<ShopDto> GetShopsByRunId(long id, DayOfWeek? day)
	{
		IQueryable<DailyRoutePlan> plans;

		if ( day != null )
		{
			plans = _dataContext.DailyRoutePlans
			                    .Where( x => x.RunId == id && x.DayOfWeek.Equals( day ) );
		} else
		{
			plans = _dataContext.DailyRoutePlans
			                    .Where( x => x.RunId == id );
		}

		return plans.Include( x => x.Shop )
		            .Select( x => new ShopDto { ID = x.Shop.Id, Name = x.Shop.CompanyName, } ).ToList();
	}

	[HttpPost]
	public void AddRun(RunDto run)
	{
		var newRun = new Run
			{
			Id = run.Id,
			LocationArea = run.LocationArea,
			DailyRoutePlans = new List<DailyRoutePlan>()
			};

		_dataContext?.AddAsync( newRun );
	}
	
}