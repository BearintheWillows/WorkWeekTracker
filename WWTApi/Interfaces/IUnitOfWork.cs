namespace WWTApi.Interfaces;

using DataModels.WorkModels;

public interface IUnitOfWork
{
	IRepository<Run>   RunsRepository   { get; }
	IRepository<Shift> ShiftsRepository { get; }
	IRepository<Break> BreaksRepository{ get; }
	IRepository<Shop>  ShopsRepository  { get; }
	void               Commit();
}