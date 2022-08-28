namespace WWTApi.Data.Repository;

using DataModels.WorkModels;
using DataModels.WorkModels.DTOs.RunDTOs;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class RunRepository : BaseRepository<Run>, IRunRepository
{
	public RunRepository(DataContext context) : base( context )
	{ }

	public async Task<Run?> GetRunByIdAsync(int id)
	{
		return await GetAll().SingleOrDefaultAsync( r => r.RunId == id );
	}

	public async Task<List<RunDetailDto>> GetRunShopsById(int id)
	{
		return await _context.Runs.Include( r => r.Shops ).Where( r => r.RunId == id ).Select( r => new RunDetailDto
				{
				RunId = r.RunId,
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
		).ToListAsync();
	}
}