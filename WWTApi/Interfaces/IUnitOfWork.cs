namespace WWTApi.Interfaces;

using DataModels.WorkModels;

public interface IUnitOfWork
{
	IRepository<Run>   Runs   { get; }
	IRepository<Shift> Shifts { get; }
	IRepository<Break> Breaks { get; }
	IRepository<Shop>  Shops  { get; }
	void               Commit();
}