namespace DataModels.WorkModels.DTOs.RunDTOs;

public class RunDto
{
	public int     RunId        { get; set; } = 0;

	public int     Number       { get; set; } = 0;

	public DayOfWeek DayOfWeek    { get; set; } = new();
	public string?   LocationArea { get; set; } = String.Empty;
	public int       ShiftCount   { get; set; } = 0;
	public int       ShopCount    { get; set; } = 0;
	
	public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();
	public virtual ICollection<Shop>             Shops  { get; set; } = new List<Shop>();
}