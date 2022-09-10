namespace WWTApi.Data.WorkModels;

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

public class Run
{
	
	[DatabaseGenerated(DatabaseGeneratedOption.None)]

	public int Id { get;               set; }
	public string? LocationArea { get; set; } = String.Empty;
	
	public virtual ICollection<DailyRoute> DailyRoutePlans { get; set; }
	
	public static async Task<bool> Delete(int id, DataContext? dataContext)
	{
		var run = await dataContext.Runs.FindAsync( id );
		if ( run ==  null )
		{
			return false;
		}

		dataContext.Runs.Remove( run );
		await dataContext.SaveChangesAsync();
		
		return true;
	}
	
	
	
}