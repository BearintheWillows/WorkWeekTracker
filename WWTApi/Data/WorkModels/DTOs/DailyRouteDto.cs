namespace WWTApi.Data.WorkModels.DTOs;

public class DailyRouteDto
{
	public int? Id{ get; set; }
	
	public string? Location { get; set; }

	public string? DeliveryDay { get; set; }
	public List<dynamic>? Shops { get; set; }
}