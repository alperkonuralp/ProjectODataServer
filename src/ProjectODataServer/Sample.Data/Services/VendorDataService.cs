using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using ProjectODataServer.EF.Services;
using ProjectODataServer.Services;
using Sample.Data.Entities;
using System.Linq;

namespace Sample.Data.Services
{
	public class VendorDataService : DataEntityFrameworkService<Vendor, int>, IVendorDataService
	{
		private readonly DbContext _db;

		public VendorDataService(DbContext db, ILogger logger) : base(db, logger)
		{
			_db = db;
		}

		public IQueryable<Product> GetProducts(int key)
		{
			if (!_db.Set<Vendor>().Any(x => x.Id == key)) throw new NotFoundException();

			return _db.Set<Product>().Where(x => x.VendorId == key);
		}
	}
}