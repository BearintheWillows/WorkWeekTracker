namespace DataModels.WorkModels.DTOs.ShopDtos;

public class ShopDto
{
	public int     ID   { get; set; }
	public string  Name     { get; set; } = String.Empty;
	public string  Address1 { get; set; } = String.Empty;
	public string? Address2 { get; set; } = String.Empty;
	public string? Address3 { get; set; } = string.Empty;
	public string? City     { get; set; } = String.Empty;
	public string? County   { get; set; } = String.Empty;
	public string  PostCode { get; set; } = string.Empty;
	public string? Notes    { get; set; } = String.Empty;
	
	//Navigation Properties
	public virtual ICollection<Run>         Runs         { get; set; } = new List<Run>();
}