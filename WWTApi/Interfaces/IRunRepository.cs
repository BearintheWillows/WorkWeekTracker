namespace WWTApi.Interfaces;

using DataModels.WorkModels;
using DataModels.WorkModels.DTOs.RunDTOs;

public interface IRunRepository : IRepository<Run>
{
	Task<List<RunDto>>             GetAllRuns();
	Task<Run?>                     GetRunByIdAsync(int id);
	Task<Task<List<DailyRoutePlan>>> GetRunShopsById(int id);
	
}