using ProjectODataServer.Entities;
using System.Linq;

namespace ProjectODataServer.Services
{
	public interface IDataService<TEntity, TKey> 
		where TEntity : Entity<TKey>
	{
		IQueryable<TEntity> Get();

		IQueryable<TEntity> Get(TKey key);

		TEntity Post(TEntity item);

		void Patch(TKey key, IDelta<TEntity> item);

		void Put(TKey key, TEntity item);

		void Delete(TKey key);
	}
}