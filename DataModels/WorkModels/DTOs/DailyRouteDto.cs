namespace DataModels.WorkModels.DTOs;

public class DailyRouteDto
{
	public int RunId  { get; set; }
	public int ShopId { get; set; }
	
	public Run Run { get; set; }
	public List<ShopDto> Shops { get; set; }
}