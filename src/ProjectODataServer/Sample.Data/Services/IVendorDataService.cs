using ProjectODataServer.Services;
using Sample.Data.Entities;
using System.Linq;

namespace Sample.Data.Services
{
	public interface IVendorDataService : IDataService<Vendor, int>
	{
		IQueryable<Product> GetProducts(int key);
	}
}