namespace DataModels.WorkModels.DTOs.RunDTOs;

public class RunDetailDto : RunDto
{
	public int ShiftCount { get; set; } = 0;
	public int ShopCount  { get; set; } = 0;
	
	public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();
	public virtual ICollection<Shop>             Shops  { get; set; } = new List<Shop>();
}