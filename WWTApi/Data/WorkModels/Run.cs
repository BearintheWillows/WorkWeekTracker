namespace WWTApi.Data.WorkModels;

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

public class Run
{
	[DatabaseGenerated( DatabaseGeneratedOption.None )]

	public int Id { get; init; }

	public string? Location { get; set; } = String.Empty;

	public virtual ICollection<DailyRoute>? DailyRoutePlans { get; set; }

	public static async Task<bool> Delete(int id, DataContext? dataContext)
	{
		var run = await dataContext.Runs.FindAsync( id );
		if ( run == null )
		{
			return false;
		}

		dataContext.Runs.Remove( run );
		await dataContext.SaveChangesAsync();

		return true;
	}

	public static async Task<bool> Edit(int id, Run run, DataContext? dataContext)
	{
		var existingRun = await dataContext.Runs.FindAsync( id );
		if ( existingRun == null )
		{
			return false;
		}

		existingRun.Location = run.Location;

		dataContext.Runs.Update( existingRun );
		await dataContext.SaveChangesAsync();

		return true;
	}

	public static async Task<bool> Create(Run run, DataContext? dataContext)
	{
		var newRun = new Run { Id = run.Id, Location = run.Location, DailyRoutePlans = null, };

		if ( dataContext.Runs.Add( newRun ) != null )
		{
			await dataContext.SaveChangesAsync();
			return true;
		}

		return false;
	}
}