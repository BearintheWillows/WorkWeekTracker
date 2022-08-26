namespace WWTApi.Controllers;

using System.Collections;
using System.Text.Json;
using DataModels.WorkModels.DTOs.RunDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Repository;
using DataModels.WorkModels;

[ApiController]
[Route( "api/[controller]" )]
public class RunController : ControllerBase
{
	private DataContext _context;
	private UnitOfWork  _unitOfWork;

	public RunController(DataContext context)
	{
		_context = context;
		_unitOfWork = new UnitOfWork(_context);
	}

	[HttpGet]
	public async Task<List<RunDetailDto>> GetRuns()
	{
		return _unitOfWork.RunsRepository.Include( r => r.Shops ).Select( r => new RunDetailDto()
			{
			RunId = r.RunId,
			Number = r.Number,
			DayOfWeek = r.DayOfWeek,
			Shops = r.Shops.Select( s => new Shop
					{
					Name = s.Name,
					Address1 = s.Address1,
					City = s.City,
					County = s.County,
					PostCode = s.PostCode,
					Notes = s.Notes,
					}
			).ToList(),
			}
		).ToList();
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
				                         }
		                         ).SingleAsync( r => r.RunId == id );

		return run;
	}

	[HttpGet( "{id}/Shops" )]
	public async Task<string> GetShops(int id)
	{
		var response = await _context.Runs.Where( r => r.RunId == id ).Select( r => new RunDetailDto
				{
				Number = r.Number,
				DayOfWeek = r.DayOfWeek,
				Shops = r.Shops.Select( s => new Shop
						{
						Name = s.Name,
						Address1 = s.Address1,
						City = s.City,
						County = s.County,
						PostCode = s.PostCode,
						Notes = s.Notes,
						}
				).ToList(),
				}
		).SingleOrDefaultAsync();

		return JsonSerializer.Serialize<RunDetailDto>( response );
	}
}