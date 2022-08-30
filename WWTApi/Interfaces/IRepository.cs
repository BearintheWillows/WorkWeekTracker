namespace WWTApi.Interfaces;

using System.Linq.Expressions;

public interface IRepository<TEntity> where TEntity : class
{
	/// <summary>
	/// Interface to Delete an Object of matching type
	/// </summary>
	/// <param name="entityToDelete"></param>
	void Delete(TEntity entityToDelete);

	/// <summary>
	/// Interface to Delete an object by matching Id
	/// </summary>
	/// <param name="id"></param>
	void Delete(object id);

	/// <summary>
	/// Interface to retrieve all Entities of a matching type
	/// </summary>
	/// <param name="filter"></param>
	/// <param name="orderBy"></param>
	/// <param name="includeProperties"></param>
	/// <returns>IEnumerable<TEntity></returns>
	IEnumerable<TEntity> Get(
		Expression<Func<TEntity, bool>>                       filter            = null,
		Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy           = null,
		string                                                includeProperties = ""
	);

	/// <summary>
	/// Interface to get an Entity by id
	/// </summary>
	/// <param name="id"></param>
	/// <returns>TEntity</returns>
	TEntity GetById(object id);
	
	/// <summary>
	/// Interface to add an entity
	/// </summary>
	/// <param name="entity"></param>
	void Insert(TEntity entity);

	/// <summary>
	/// Interface to update an Entity
	/// </summary>
	/// <param name="entityToUpdate"></param>
	void Update(TEntity entityToUpdate);

	/// <summary>
	/// Replicates the Include method of a database
	/// </summary>
	/// <param name="includes"></param>
	/// <returns></returns>
	IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes);
}