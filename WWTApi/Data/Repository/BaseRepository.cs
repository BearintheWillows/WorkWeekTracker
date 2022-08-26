namespace WWTApi.Data.Repository;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
	internal DataContext _context;

	internal DbSet<TEntity> _dbSet;

	public BaseRepository(DataContext context, DbSet<TEntity> dbSet)
	{
		_context = context;
		_dbSet = dbSet;
	}
	

	public virtual IEnumerable<TEntity> Get(
		Expression<Func<TEntity, bool>>                       filter            = null,
		Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy           = null,
		string                                                includeProperties = "")
	{
		IQueryable<TEntity> query = _dbSet;

		if (filter != null)
		{
			query = query.Where(filter);
		}

		if (includeProperties != null)
		{
			foreach (var includeProperty in includeProperties.Split
				         (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}
		}
            

		if (orderBy != null)
		{
			return orderBy(query).ToList();
		}
		else
		{
			return query.ToList();
		}
	}

	public virtual TEntity GetById(object id)
	{
		return _dbSet.Find(id);
	}

	public virtual void Insert(TEntity entity)
	{
		_dbSet.Add(entity);
	}

	public virtual void Delete(object id)
	{
		TEntity entityToDelete = _dbSet.Find(id);
		Delete(entityToDelete);
	}

	public virtual void Delete(TEntity entityToDelete)
	{
		if (_context.Entry(entityToDelete).State == EntityState.Detached)
		{
			_dbSet.Attach(entityToDelete);
		}
		_dbSet.Remove(entityToDelete);
	}

	public virtual void Update(TEntity entityToUpdate)
	{
		_dbSet.Attach(entityToUpdate);
		_context.Entry(entityToUpdate).State = EntityState.Modified;
	}

}