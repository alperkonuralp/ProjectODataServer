using System;
using System.Collections.Generic;

namespace ProjectODataServer.Services
{
	public interface IDelta<TStructuralType>
	{
		Type StructuredType { get; }
		Type ExpectedClrType { get; }

		void Clear();

		//
		// Summary:
		//     Copies the changed property values from the underlying entity (accessible via
		//     Microsoft.AspNet.OData.Delta`1.GetInstance) to the original entity recursively.
		//
		// Parameters:
		//   original:
		//     The entity to be updated.
		void CopyChangedValues(TStructuralType original);

		//
		// Summary:
		//     Copies the unchanged property values from the underlying entity (accessible via
		//     Microsoft.AspNet.OData.Delta`1.GetInstance) to the original entity.
		//
		// Parameters:
		//   original:
		//     The entity to be updated.
		void CopyUnchangedValues(TStructuralType original);

		//
		// Summary:
		//     Returns the known properties that have been modified through this Microsoft.AspNet.OData.Delta
		//     as an System.Collections.Generic.IEnumerable`1 of property Names. Includes the
		//     structural properties at current level. Does not include the names of the changed
		//     dynamic properties.
		IEnumerable<string> GetChangedPropertyNames();

		//
		// Summary:
		//     Returns the instance that holds all the changes (and original values) being tracked
		//     by this Delta.
		TStructuralType GetInstance();

		//
		// Summary:
		//     Returns the known properties that have not been modified through this Microsoft.AspNet.OData.Delta
		//     as an System.Collections.Generic.IEnumerable`1 of property Names. Does not include
		//     the names of the changed dynamic properties.
		IEnumerable<string> GetUnchangedPropertyNames();

		//
		// Summary:
		//     Overwrites the original entity with the changes tracked by this Delta. The semantics
		//     of this operation are equivalent to a HTTP PATCH operation, hence the name.
		//
		// Parameters:
		//   original:
		//     The entity to be updated.
		void Patch(TStructuralType original);

		//
		// Summary:
		//     Overwrites the original entity with the values stored in this Delta. The semantics
		//     of this operation are equivalent to a HTTP PUT operation, hence the name.
		//
		// Parameters:
		//   original:
		//     The entity to be updated.
		void Put(TStructuralType original);

		bool TryGetPropertyType(string name, out Type type);

		bool TryGetPropertyValue(string name, out object value);

		bool TrySetPropertyValue(string name, object value);
	}
}