namespace WWTApi.Data.Repository;

using DataModels.WorkModels;
using Interfaces;

public class UnitOfWork : IUnitOfWork
{
	private DataContext           _dbContext;
	private BaseRepository<Run>   _runs;
	private BaseRepository<Break> _breaks;
	private BaseRepository<Shift> _shifts;
	private BaseRepository<Shop>  _shops;

	public UnitOfWork(DataContext dbContext)
	{
		_dbContext = dbContext;
	}

	public       IRepository<Run>   RunsRepository     => _runs ?? ( _runs = new BaseRepository<Run>( _dbContext ) );
	public       IRepository<Shift> ShiftsRepository   => _shifts ?? ( _shifts = new BaseRepository<Shift>( _dbContext ) );
	public       IRepository<Break> BreaksRepository   => _breaks ?? ( _breaks = new BaseRepository<Break>( _dbContext ) );
	public       IRepository<Shop>  ShopsRepository    => _shops ?? ( _shops = new BaseRepository<Shop>( _dbContext ) );
	public async void               Commit() => await _dbContext.SaveChangesAsync();
}