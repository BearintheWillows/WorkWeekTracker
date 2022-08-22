

namespace WWTClient.Pages.Shops;

using System.Net.Http.Json;
using System.Text.Json;
using DataModels.WorkModels;
using DataModels.WorkModels.DTOs.RunDTOs;
using Microsoft.AspNetCore.Components;

public partial class ShopList 
{
	[Inject]
	private HttpClient? Http { get; init; }
	[Parameter]
	public long Id { get; set; }

	[Parameter]
	public RunDetailDto? Run { get; set; } = new();
	
	
	

	protected override async Task OnParametersSetAsync()
	{
		await UpdateData();
		Console.WriteLine(Run.ToString());
	}

	public async Task UpdateData()
	{
		if ( Http != null )
		{

			Run = await Http.GetFromJsonAsync<RunDetailDto>( $"/api/Run/{Id}/Shops" ) ?? new RunDetailDto();
			;

		}
		
	}


}