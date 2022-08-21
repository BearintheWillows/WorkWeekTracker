using WWTClient.Interfaces;

namespace WWTClient.Pages.Runs;

using System.Net.Http.Json;
using DataModels.WorkModels.DTOs.RunDTOs;
using Microsoft.AspNetCore.Components;

public partial class RunDetail : IHttpClient
{
	[Inject]
	public HttpClient? Http { get; set; }

	[Parameter]
	public int? Id { get; set; } = 0;

	[Parameter]
	public RunDetailDto? Run { get; set; } = new();

	protected override async Task OnInitializedAsync() => await UpdateData();

	public async Task UpdateData()
	{
		if ( Http != null )
		{
			Run = await Http.GetFromJsonAsync<RunDetailDto>( $"/api/run/{Id}" ) ?? new RunDetailDto();
		}
	}
}