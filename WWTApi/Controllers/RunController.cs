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
	private IRunRepository _runRepository;

	// public RunController()
	// {
	// 	_runRepository = new RunRepository( new DataContext( ) );
	// }

	public RunController(IRunRepository runRepository)
	{
		_runRepository = runRepository;
	}
	
	//
	// GET: /run/

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
	public async Task<Task<List<DailyRoutePlan>>> GetRunShops(int id)
	{
		return await _runRepository.GetRunShopsById( id );
	}
	
	
}