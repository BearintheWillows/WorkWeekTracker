namespace WWTClient.Pages.Runs.Shops;

using System.Net.Http.Json;
using DataModels.WorkModels.DTOs.RunDTOs;
using Microsoft.AspNetCore.Components;

public partial class ShopList
{
	[Inject]
	private HttpClient? Http { get; init; }

	[Parameter]
	public long Id { get; set; }

	[Parameter]
	public RunDto? Run { get; set; } = new();


	protected override async Task OnParametersSetAsync()
	{
		await UpdateData();
	}

	public async Task UpdateData()
	{
		if ( Http != null )
		{
			Run = await Http.GetFromJsonAsync<RunDto>( $"/api/Run/{Id}/Shops" ) ?? new RunDto();
		}
	}
	
	public static string GetDetailsUrl(int id) => $"shop/detail/{id}";
}