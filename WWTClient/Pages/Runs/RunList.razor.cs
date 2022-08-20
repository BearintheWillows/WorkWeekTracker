namespace WWTClient.Pages.Runs;

using System.Net.Http.Json;
using DataModels.WorkModels;
using DataModels.WorkModels.DTOs.RunDTOs;
using Microsoft.AspNetCore.Components;

public partial class RunList
{
	[Inject]
	public HttpClient? Http { get; set; }

	[Parameter]
	public IEnumerable<RunDto> Runs { get; set; } = Enumerable.Empty<RunDto>();

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		await UpdateData();
	}
	private async Task UpdateData() {
		if (Http != null) {
			Runs = await Http.GetFromJsonAsync<IEnumerable<RunDto>>("/api/run") ?? new List<RunDto>();
		}
	}
	// string GetEditUrl(long    id) => $"forms/edit/{id}";
	// string GetDetailsUrl(long id) => $"forms/details/{id}";
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