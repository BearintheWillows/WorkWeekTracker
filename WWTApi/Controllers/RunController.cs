namespace WWTApi.Controllers;

using System.Runtime.Intrinsics.X86;
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
	[HttpGet]
	public async Task<List<Run>?> GetAll()
	{
		return await _dataContext?.Runs.ToListAsync();
	}

	//GET BY ID
	//
	[HttpGet( "{id}" )]
	public async Task<Run>? GetRunById(long id)
	{
		return await _dataContext.Runs.SingleOrDefaultAsync( r => r.Id == id );
	}

	//GET SHOPS OF RUN BY ID
	//
	[HttpGet( "{id}/shops/{day?}" )]
	public List<ShopDto> GetShopsByRunId(long id ,  DayOfWeek? day)
	{
		
		
		IQueryable<DailyRoutePlan> plans;
		
		if ( day != null )
		{
			plans = _dataContext.DailyRoutePlans
			                    .Where( x => x.RunId == id && x.DayOfWeek.Equals( day ));
		} else
		{
			plans = _dataContext.DailyRoutePlans
			                    .Where( x => x.RunId == id );
		}
		
		return plans.Include( x => x.Shop )
		            .Select( x => new ShopDto
			             {
			             ID = x.Shop.Id,
			             Name = x.Shop.CompanyName,
			             } ).ToList();
	}
}