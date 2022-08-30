namespace DataModels.WorkModels;

using System.ComponentModel.DataAnnotations.Schema;

public class Run
{
	
	[DatabaseGenerated(DatabaseGeneratedOption.None)]

	public int Id { get;           set; }
	public string LocationArea { get; set; } = String.Empty;
	
	
	public virtual ICollection<DailyRoutePlan> DailyRoutePlans { get; set; }
	
}