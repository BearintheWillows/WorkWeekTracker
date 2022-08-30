namespace DataModels.WorkModels;

public class Shop
{
	public int     Id          { get; set; }
	public string  CompanyName { get; set; } = String.Empty;
	public string? StoreType   { get; set; }
	public string  Address1    { get; set; } = String.Empty;
	public string? Address2    { get; set; }
	public string? Address3    { get; set; }
	public string? City        { get; set; }
	public string? County      { get; set; }
	public string  PostCode    { get; set; } = string.Empty;
	public string? Notes       { get; set; }

	//Navigation Properties
	public virtual ICollection<DailyRoutePlan> DailyRoutePlans { get; set; }

}