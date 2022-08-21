namespace DataModels.WorkModels.DTOs.RunDTOs;

public class RunNavsDto : RunDto
{
	public IQueryable<Shop>  Shops  { get; set; } = new List<Shop>().AsQueryable();
	public IQueryable<Shift> Shifts { get; set; } = new List<Shift>().AsQueryable();

}