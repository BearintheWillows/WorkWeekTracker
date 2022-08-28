namespace WWTClient.Pages.Runs;

using System.Net.Http.Json;
using System.Reflection.Metadata;
using DataModels.WorkModels;
using DataModels.WorkModels.DTOs.RunDTOs;
using Microsoft.AspNetCore.Components;

public partial class RunList
{
	[Inject]
	public HttpClient? Http { get;                set; }
	public        bool[]?      Collapsible { get; set; }
	public        RunDto SelectedBaseRun;
	public static int          ArraySize { get; set; }
	
	
	[Parameter]
	public static ICollection<RunDto> Runs { get; set; } = new List<RunDto>();

	public IEnumerable<Shop>? Shops { get; set; } = new List<Shop>();

	protected override async Task OnInitializedAsync()
	{
		// NewRuns = Collapsible.Select( x => new BaseRunDetailDto() ).ToArray();

		await base.OnInitializedAsync();
		await UpdateData();
		Collapsible = new bool[ ArraySize ];

	}
	private async Task UpdateData()
	{
		if (Http != null) {
			Runs = await Http.GetFromJsonAsync<ICollection<RunDto>>("/api/run") ?? new List<RunDto>();
		}
		ArraySize = Runs.Count + 1;
		Console.WriteLine(ArraySize);
		
		
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