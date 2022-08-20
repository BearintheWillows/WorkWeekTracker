using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using WWTClient.Shared.Templates;
using DataModels.WorkModels;

namespace WWTClient.Pages;



public partial class List
{
	[Inject]
	public HttpClient? Http { get; set; }

	[Parameter]
	public IEnumerable<Run>? Runs { get; set; } = Enumerable.Empty<Run>();

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		await UpdateData();
	}
	private async Task UpdateData() {
		if (Http != null) {
			Runs = await Http.GetFromJsonAsync<IEnumerable<Run>>("/api/run") ?? new List<Run>();
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