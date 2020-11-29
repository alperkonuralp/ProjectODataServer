using ProjectODataServer.Services;
using System;
using System.Collections.Generic;

namespace ProjectODataServer.Controllers.OData
{
	public class Delta<TEntity> : IDelta<TEntity>
		where TEntity : class
	{
		public Microsoft.AspNet.OData.Delta<TEntity> DeltaObject { get; set; }

		public Delta(Microsoft.AspNet.OData.Delta<TEntity> deltaObject)
		{
			DeltaObject = deltaObject;
		}

		public Type StructuredType => DeltaObject.StructuredType;

		public Type ExpectedClrType => DeltaObject.ExpectedClrType;

		public void Clear()
		{
			DeltaObject.Clear();
		}

		public void CopyChangedValues(TEntity original)
		{
			DeltaObject.CopyChangedValues(original);
		}

		public void CopyUnchangedValues(TEntity original)
		{
			DeltaObject.CopyUnchangedValues(original);
		}

		public IEnumerable<string> GetChangedPropertyNames() => DeltaObject.GetChangedPropertyNames();

		public TEntity GetInstance() => DeltaObject.GetInstance();

		public IEnumerable<string> GetUnchangedPropertyNames() => DeltaObject.GetUnchangedPropertyNames();

		public void Patch(TEntity original)
		{
			DeltaObject.Patch(original);
		}

		public void Put(TEntity original)
		{
			DeltaObject.Put(original);
		}

		public bool TryGetPropertyType(string name, out Type type)
		{
			return DeltaObject.TryGetPropertyType(name, out type);
		}

		public bool TryGetPropertyValue(string name, out object value)
		{
			return DeltaObject.TryGetPropertyValue(name, out value);
		}

		public bool TrySetPropertyValue(string name, object value)
		{
			return DeltaObject.TrySetPropertyValue(name, value);
		}
	}
}