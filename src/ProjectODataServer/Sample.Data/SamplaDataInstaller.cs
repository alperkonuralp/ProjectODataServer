using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ProjectODataServer.EF.Services;
using ProjectODataServer.Services;
using Sample.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Data
{
	public class SamplaDataInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Component
					.For<IDataService<Category, int>>()
					.ImplementedBy<DataEntityFrameworkService<Category, int>>()
					.LifestyleScoped()
				,
				Component
					.For<IDataService<Product, int>>()
					.ImplementedBy<DataEntityFrameworkService<Product, int>>()
					.LifestyleScoped()
				,
				Component
					.For<IDataService<ServiceCategory, int>>()
					.ImplementedBy<DataEntityFrameworkService<ServiceCategory, int>>()
					.LifestyleScoped()
				,
				Component
					.For<IDataService<ServiceProduct, int>>()
					.ImplementedBy<DataEntityFrameworkService<ServiceProduct, int>>()
					.LifestyleScoped()
				,
				Component
					.For<IDataService<ShoppingCategory, int>>()
					.ImplementedBy<DataEntityFrameworkService<ShoppingCategory, int>>()
					.LifestyleScoped()
				,
				Component
					.For<IDataService<ShoppingProduct, int>>()
					.ImplementedBy<DataEntityFrameworkService<ShoppingProduct, int>>()
					.LifestyleScoped()
				,
				Component
					.For<IDataService<Vendor, int>>()
					.ImplementedBy<DataEntityFrameworkService<Vendor, int>>()
					.LifestyleScoped()


				);
		}
	}
}
