namespace WWTApi.Controllers;

using DataModels.Models;
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

	[HttpGet( "{Id}" )]
	public async Task<Run> GetDetails(int Id)
	{
		return await _context.Runs.FindAsync(Id);
	}
}