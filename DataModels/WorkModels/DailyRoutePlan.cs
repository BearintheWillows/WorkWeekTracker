namespace DataModels.WorkModels;

using System.Collections;

public class DailyRoutePlan
{
	public int       Id        { get; set; }
	public DayOfWeek DayOfWeek { get; set; }

	public int  ShopId { get; set; }
	public int  RunId  { get; set; }


	public virtual Run Run  { get; set; }
	public virtual Shop       Shop { get; set; }

}