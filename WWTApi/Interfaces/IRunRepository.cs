namespace WWTApi.Interfaces;

using DataModels.WorkModels;

public interface IRunRepository : IDisposable
{
	Task<IEnumerable<Run>> GetRuns();
	Run              GetRunById(int id);
	void             InsertRun(Run  run);
	void             DeleteRun(int  id);
	void             UpdateRun(Run  run);
	void             Save();
}