namespace DataModels.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Break
{
	public int      BreakId        { get; set; }
	[DataType(DataType.Time), DisplayFormat(DataFormatString = "hh:mm tt")]
	public DateTime StartTime { get; set; }
	[DataType(DataType.Time), DisplayFormat(DataFormatString = "hh:mm tt")]
	public DateTime EndTime   { get; set; }
	public string?  Location  { get; set; }
	
	//Navigation Properties
	public virtual Shift Shift { get; set; } = new Shift();

	public TimeSpan GetDuration()
	{
		TimeSpan duration = EndTime - StartTime;
		return duration;
	}
}