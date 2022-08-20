namespace WWTApi.Controllers;

using DataModels.WorkModels;
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
	public async Task<IAsyncEnumerable<Run>>? GetAll()
	{
		return _context.Runs.AsAsyncEnumerable();
	}
}