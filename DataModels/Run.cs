namespace DataModels.Models;

using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

public class Run
{
	public int RunId { get;           set; }
	
	public int Number { get;           set; } = 0;
	public string LocationArea { get; set; } = String.Empty;

	public DayOfWeek DayOfWeek { get; set; }
	
	
	//Navigational Properties
	public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();
	public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();
}