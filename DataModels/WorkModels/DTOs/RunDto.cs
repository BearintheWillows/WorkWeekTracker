namespace DataModels.WorkModels.DTOs;

public class RunDto
{
	public int     Id           { get; set; } = 0;
	public string? LocationArea { get; set; } = String.Empty;
	public int     ShiftCount   { get; set; } = 0;
	public int     ShopCount    { get; set; } = 0;
	
	public virtual List<ShopDto> Shops { get; set; } = new List<ShopDto>();
	
}