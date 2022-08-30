namespace WWTApi.Data.Repository;

using DataModels.WorkModels;
using DataModels.WorkModels.DTOs.RunDTOs;
using Interfaces;
using Microsoft.EntityFrameworkCore;

// public class RunRepository : BaseRepository<Run>, IRunRepository
// {
// 	public RunRepository(DataContext context) : base( context )
// 	{ }
//
// 	public async Task<List<RunDto>> GetAllRuns()
// 	{
// 		return await _context.Runs.Select( r => new RunDto() { Id = r.Id} ).ToListAsync(  );
// 	}
//
// 	public async Task<Run?> GetRunByIdAsync(int id)
// 	{
// 		return await GetAll().SingleOrDefaultAsync( r => r.Id == id );
// 	}
//
// 	public async Task<Task<List<DailyShopRun>>> GetRunShopsById(int id)
// 	{
// 		return _context.Runs.Where( x => x.Id == id ).Include( r => r.DailyShopRuns ).Select( _ => new RunDto
// 			{
// 			Id = _.Id,
// 			Shops = _.DailyShopRuns.
// 			} )
//
// 	}
// }