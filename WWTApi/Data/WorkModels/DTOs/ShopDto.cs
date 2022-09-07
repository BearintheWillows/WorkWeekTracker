namespace WWTApi.Data.WorkModels.DTOs;

public class ShopDto
{
	public int     Id   { get; set; }
	
	public string  Name     { get; set; } = string.Empty;
	public string  Address1 { get; set; } = string.Empty;
	public string? Address2 { get; set; } = string.Empty;
	public string? Address3 { get; set; } = string.Empty;
	public string? City     { get; set; } = string.Empty;
	public string? County   { get; set; } = string.Empty;
	public string  PostCode { get; set; } = string.Empty;
	public string? Notes    { get; set; } = string.Empty;
	
}