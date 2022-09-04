namespace WWTApi.Controllers;

using Data;
using DataModels.WorkModels;
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
}