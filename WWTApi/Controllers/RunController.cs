namespace WWTApi.Controllers;

using System.Collections;
using System.Text.Json;
using DataModels.WorkModels.DTOs.RunDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Repository;
using DataModels.WorkModels;
using Interfaces;

[ApiController]
[Route( "api/[controller]" )]
public class RunController : ControllerBase
{
	private DataContext   _context;
	private IRunRepository _runRepository;

	public RunController(DataContext context, IRunRepository runRepository)
	{
		_context = context;
		_runRepository = runRepository;
	}

	[HttpGet]
	 public async Task<List<RunDto>> GetRuns()
	 {
		 return await _runRepository.GetAllRuns();
	 }

	[HttpGet( "{id}" )]
	public async Task<Run?> GetRun(int id)
	{
		return await _runRepository.GetRunByIdAsync( id );
		
	}

	[HttpGet( "{id}/shops")]
	public async Task<List<RunDto>> GetRunShops(int id)
	{
		return await _runRepository.GetRunShopsById( id );
	}

	// [HttpGet( "{id}/Shops" )]
	// public async Task<string> GetShops(int id)
	// {
	// 	var response = await  Select( r => new RunDetailDto
	// 			{
	// 			Number = r.Number,
	// 			DayOfWeek = r.DayOfWeek,
	// 			Shops = r.Shops.Select( s => new Shop
	// 					{
	// 					Name = s.Name,
	// 					Address1 = s.Address1,
	// 					City = s.City,
	// 					County = s.County,
	// 					PostCode = s.PostCode,
	// 					Notes = s.Notes,
	// 					}
	// 			).ToList(),
	// 			}
	// 	).SingleOrDefaultAsync();
	//
	// 	return JsonSerializer.Serialize<RunDetailDto>( response );
	// }
}