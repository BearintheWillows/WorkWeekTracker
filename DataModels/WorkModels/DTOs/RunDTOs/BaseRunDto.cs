namespace DataModels.WorkModels.DTOs.RunDTOs;

public class BaseRunDto
{
	public         int               RunId     { get; set; }
	public         int               Number    { get; set; } = 0;
	public         DayOfWeek         DayOfWeek { get; set; }

}