namespace WWTApi.Interfaces;

using DataModels.WorkModels;
using DataModels.WorkModels.DTOs.RunDTOs;

public interface IRunRepository : IRepository<Run>
{
	Task<Run?>               GetRunByIdAsync(int id);
	Task<List<RunDetailDto>> GetRunShopsById(int id);
}