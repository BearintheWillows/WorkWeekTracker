namespace WWTApi.Controllers;

using DataModels.WorkModels;
using DataModels.WorkModels.DTOs.RunDTOs;
using Microsoft.AspNetCore.Mvc;
using WWTApi.Data;

[ApiController]
[Route("api/[controller]/")]
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
				   select  new RunDto()
					   {
					   Number = r.Number,
					   LocationArea = r.LocationArea,
					   DayOfWeek = r.DayOfWeek,
					   };
		return runs;
	}
}