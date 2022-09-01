namespace DataModels.WorkModels;

using System.Collections;

public class DailyRoutePlan
{
	public int       RunId     { get; set; }
    public int       ShopId    { get; set; }
    public DayOfWeek DayOfWeek { get; set; }

   public Shop Shop {get; set;}
   public Run Run {get; set;}

}