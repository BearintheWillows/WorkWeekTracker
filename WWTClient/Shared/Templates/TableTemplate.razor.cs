namespace WWTClient.Shared.Templates;

using Microsoft.AspNetCore.Components;

public partial class TableTemplate<TRowType>
{
	

[Parameter]
public RenderFragment? Header { get; set; }

[Parameter]
public RenderFragment<TRowType>? RowTemplate { get; set; }

[Parameter]
public IEnumerable<TRowType> RowData { get; set; } = Enumerable.Empty<TRowType>();




}