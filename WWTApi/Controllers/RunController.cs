namespace WWTApi.Controllers;

using DataModels.WorkModels.DTOs.RunDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;

[ApiController]
[Route( "api/[controller]/" )]
public class RunController : ControllerBase
{
	private DataContext _context;

	public RunController(DataContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<IQueryable<RunDto>> GetRuns()
	{
		var runs = from r in _context.Runs
		           select new RunDto() { RunId = r.RunId, Number = r.Number, LocationArea = r.LocationArea, DayOfWeek = r.DayOfWeek, };
		return runs;
	}

	[HttpGet( "{id}" )]
	public async Task<RunDetailDto> GetRun(int id)
	{
		var run = await _context.Runs
		                  .Include( r => r.Shifts )
		                  .Include( r => r.Shops )
		                  .Select( r => new RunDetailDto()
				                   {
				                   RunId = r.RunId,
				                   Number = r.Number,
				                   LocationArea = r.LocationArea,
				                   DayOfWeek = r.DayOfWeek,
				                   ShiftCount = r.Shifts.Count(),
				                   ShopCount = r.Shops.Count()
				                   }).SingleAsync(r => r.RunId == id);
		
		return run;
	}
}