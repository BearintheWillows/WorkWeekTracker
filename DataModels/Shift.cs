namespace DataModels.Models;

using System.ComponentModel.DataAnnotations;

public class Shift
{
	public int              ShiftId   { get; set; }
	[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
	public DateTime         Date      { get; set; }
	[DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
	public DateTime         StartTime { get; set; }
	[DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
	public DateTime?         EndTime   { get; set; }
	
	//Navigation Properties
	public virtual ICollection<Run> Runs {get; set; } = new List<Run>();
	public virtual ICollection<Break> Breaks  {get;  set; } = new List<Break>();
}