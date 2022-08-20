

namespace WWTClient.Pages.Shifts;

using System.Net.Http.Json;
using DataModels.WorkModels;
using Microsoft.AspNetCore.Components;

public partial class ShiftList {
	[Inject]
	public HttpClient? Http { get; set; }

	[Parameter]
	public IEnumerable<Shift> Shifts { get; set; } = Enumerable.Empty<Shift>();

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		await UpdateData();
	}
	private async Task UpdateData() {
		if (Http != null) {
			Shifts = await Http.GetFromJsonAsync<IEnumerable<Shift>>("/api/shift") ?? new List<Shift>();
		}
	}
}