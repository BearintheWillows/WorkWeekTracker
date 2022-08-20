namespace WWTApi.Controllers;

using System.Web.Http;
using System.Web.Http.Description;
using DataModels.WorkModels.DTOs.RunDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route( "api/[controller]/" )]
public class RunController : ControllerBase
{
	private DataContext _context;

	public RunController(DataContext context)
	{
		_context = context;
	}

	[Microsoft.AspNetCore.Mvc.HttpGet]
	public async Task<IQueryable<RunDto>> GetRuns()
	{
		var runs = from r in _context.Runs
		           select new RunDto() { Number = r.Number, LocationArea = r.LocationArea, DayOfWeek = r.DayOfWeek, };
		return runs;
	}

	[Microsoft.AspNetCore.Mvc.HttpGet( "{id}" )]
	[ResponseType( typeof( RunDetailDto ) )]
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