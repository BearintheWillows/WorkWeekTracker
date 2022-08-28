namespace WWTApi.Services;

using DataModels.WorkModels;
using DataModels.WorkModels.DTOs.RunDTOs;
using Interfaces;

public class RunService
{
	private readonly IRunRepository _runRepository;

	public RunService(IRunRepository runRepository)
	{
		_runRepository = runRepository;
	}
	
	

	public async Task<List<RunDetailDto>> GetRunShopsById(int id)
	{
		return await _runRepository.GetRunShopsById( id );
	}
}