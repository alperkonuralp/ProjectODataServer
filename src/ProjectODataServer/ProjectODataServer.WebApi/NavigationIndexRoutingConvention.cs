using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData.Routing.Conventions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace ProjectODataServer.WebApi
{
	public class NavigationIndexRoutingConvention : IODataRoutingConvention
	{
		public IEnumerable<ControllerActionDescriptor> SelectAction(RouteContext routeContext)
		{
			// Get a IActionDescriptorCollectionProvider from the global service provider
			IActionDescriptorCollectionProvider actionCollectionProvider =
					routeContext.HttpContext.RequestServices.GetRequiredService<IActionDescriptorCollectionProvider>();
			Contract.Assert(actionCollectionProvider != null);

			// Get OData path from HttpContext
			Microsoft.AspNet.OData.Routing.ODataPath odataPath = routeContext.HttpContext.ODataFeature().Path;
			HttpRequest request = routeContext.HttpContext.Request;

			// Handle this type of GET requests: /odata/Orders(1)/OrderRows(1)
			if (request.Method == "GET" && odataPath.PathTemplate.Equals("~/entityset/key/navigation/key"))
			{
				// Find correct controller
				string controllerName = odataPath.Segments[3].Identifier;
				IEnumerable<ControllerActionDescriptor> actionDescriptors = actionCollectionProvider
						.ActionDescriptors.Items.OfType<ControllerActionDescriptor>()
						.Where(c => c.ControllerName == controllerName || c.ControllerName == odataPath.NavigationSource.Name)
						.ToList();

				if (actionDescriptors != null)
				{
					// Find correct action
					string actionName = $"GetWith{(odataPath.Segments[0] as EntitySetSegment).EntitySet.Name}";
					var matchingActions = actionDescriptors
							.Where(c => String.Equals(c.ActionName, actionName, StringComparison.OrdinalIgnoreCase)
													&& c.Parameters.Count >= 2
													&& c.Parameters[0].Name == ODataRouteConstants.Key
													&& c.Parameters[1].Name == ODataRouteConstants.RelatedKey)
												.ToList();
					if (matchingActions.Count > 0)
					{
						// Set route data values
						var keyValueSegment = odataPath.Segments[3] as KeySegment;
						var keyValueSegmentKeys = keyValueSegment?.Keys?.FirstOrDefault();
						routeContext.RouteData.Values[ODataRouteConstants.Key] = keyValueSegmentKeys?.Value;

						var relatedKeyValueSegment = odataPath.Segments[1] as KeySegment;
						var relatedKeyValueSegmentKeys = relatedKeyValueSegment?.Keys?.FirstOrDefault();
						routeContext.RouteData.Values[ODataRouteConstants.RelatedKey] = relatedKeyValueSegmentKeys?.Value;

						// Return correct action
						return matchingActions;
					}
				}
			}

			if (request.Method == "GET" && odataPath.PathTemplate.Equals("~/entityset/key/cast/navigation/key"))
			{
				// Find correct controller
				string controllerName = odataPath.Segments[4].Identifier;
				IEnumerable<ControllerActionDescriptor> actionDescriptors = actionCollectionProvider
						.ActionDescriptors.Items.OfType<ControllerActionDescriptor>()
						.Where(c => c.ControllerName == controllerName || c.ControllerName == odataPath.NavigationSource.Name)
						.ToList();

				if (actionDescriptors != null)
				{
					// Find correct action
					string actionName = $"GetWith{(odataPath.Segments[0] as EntitySetSegment).EntitySet.Name}From{((odataPath.Segments[2] as TypeSegment).EdmType as EdmEntityType).Name}";
					var matchingActions = actionDescriptors
							.Where(c => String.Equals(c.ActionName, actionName, StringComparison.OrdinalIgnoreCase)
													&& c.Parameters.Count >= 2
													&& c.Parameters[0].Name == ODataRouteConstants.Key
													&& c.Parameters[1].Name == ODataRouteConstants.RelatedKey)
												.ToList();
					if (matchingActions.Count > 0)
					{
						// Set route data values
						var keyValueSegment = odataPath.Segments[4] as KeySegment;
						var keyValueSegmentKeys = keyValueSegment?.Keys?.FirstOrDefault();
						routeContext.RouteData.Values[ODataRouteConstants.Key] = keyValueSegmentKeys?.Value;

						var relatedKeyValueSegment = odataPath.Segments[1] as KeySegment;
						var relatedKeyValueSegmentKeys = relatedKeyValueSegment?.Keys?.FirstOrDefault();
						routeContext.RouteData.Values[ODataRouteConstants.RelatedKey] = relatedKeyValueSegmentKeys?.Value;

						// Return correct action
						return matchingActions;
					}
				}
			}
			// Not a match
			return null;
		}
	}
}