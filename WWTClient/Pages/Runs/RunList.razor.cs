namespace WWTClient.Pages.Runs;

using System.Net.Http.Json;
using System.Reflection.Metadata;
using DataModels.WorkModels;
using DataModels.WorkModels.DTOs.RunDTOs;
using Microsoft.AspNetCore.Components;

public partial class RunList
{
	[Inject]
	public HttpClient? Http { get; set; }
	public bool[]       Collapsible = new bool[15];
	public RunDetailDto SelectedBaseRun;
	
	
	[Parameter]
	public static ICollection<RunDetailDto> Runs { get; set; } = new List<RunDetailDto>();

	public IEnumerable<Shop>? Shops { get; set; } = new List<Shop>();

	protected override async Task OnInitializedAsync()
	{
		// NewRuns = Collapsible.Select( x => new BaseRunDetailDto() ).ToArray();

		await base.OnInitializedAsync();
		await UpdateData();
		
	}
	private async Task UpdateData()
	{
		if (Http != null) {
			Runs = await Http.GetFromJsonAsync<ICollection<RunDetailDto>>("/api/run") ?? new List<RunDetailDto>();
		}
		
	}
	
	public List<Shop>? GetShops(int id)
	{
		List<Shop>? shopList = new List<Shop>();
	
		foreach ( var item in Runs )
		{
			if ( item.RunId == id )
			{
				foreach ( var s in item.Shops )
				{
					shopList.Add( s );
				}
			}
		}

		return shopList;
	
		Shops = shopList;
		
	}
	
	

	public static string GetDetailsUrl(int id) => $"run/detail/{id}";
	public static string GetShopsUrl(int   id) => $"run/{id}/shops";

	
	// string GetEditUrl(long    id) => $"forms/edit/{id}";
	
	// public async Task HandleDelete(Person p) {
	// 	if (Http != null) {
	// 		HttpResponseMessage resp =
	// 			await Http.DeleteAsync($"/api/people/{p.PersonId}");
	// 		if (resp.IsSuccessStatusCode) {
	// 			await UpdateData();
	// 		}
	// 	}
	// }
}