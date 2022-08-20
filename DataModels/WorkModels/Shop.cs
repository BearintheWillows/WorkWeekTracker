namespace DataModels.WorkModels;

public class Shop
{
	public int     ShopId   { get; set; }
	public string  Name     { get; set; } = String.Empty;
	public string  Address1 { get; set; } = String.Empty;
	public string? Address2 { get; set; }
	public string? Address3 { get; set; }
	public string? City     { get; set; }
	public string? County   { get; set; }
	public string  PostCode { get; set; } = string.Empty;
	public string? Notes    { get; set; }
	
	//Navigation Properties
	public virtual ICollection<Run> Runs { get; set; } = new List<Run>();
}