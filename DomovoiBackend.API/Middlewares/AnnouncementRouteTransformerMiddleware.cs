using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json.Linq;

namespace DomovoiBackend.API.Middlewares;

public class AnnouncementRouteTransformerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

    public AnnouncementRouteTransformerMiddleware(RequestDelegate next, IActionDescriptorCollectionProvider
        actionDescriptorCollectionProvider) => 
        (_next, _actionDescriptorCollectionProvider) =
        (next, actionDescriptorCollectionProvider);

    public async Task Invoke(HttpContext context)
    {
        var routeValues = context.Request.RouteValues;
        var controllerActionDescriptor = _actionDescriptorCollectionProvider
            .ActionDescriptors
            .Items
            .FirstOrDefault(ad => ad is ControllerActionDescriptor { ControllerName: "Announcement" });

        if (controllerActionDescriptor == null)
        {
            await _next(context);
            return;
        }

        var endpoint = context.GetEndpoint();
        
        var announcementRouteAttributes = controllerActionDescriptor
            .EndpointMetadata
            .OfType<RouteAttribute>()
            .FirstOrDefault();
        
        if (announcementRouteAttributes == null)
        {
            await _next(context);
            return;
        }

        if (!context.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
        {
            await _next(context);
            return;
        }

        var originalBody = context.Request.Body;

        try
        {
            using var updatedBody = new MemoryStream();
            context.Request.Body = updatedBody;

            using var requestReader = new StreamReader(originalBody);
            var requestBody = await requestReader.ReadToEndAsync();

            var realityType = routeValues["realityType"]?.ToString();
            var dealType = routeValues["dealType"]?.ToString();

            var updatedRequestBody = GetJsonRequestWithTypes(requestBody, realityType!, dealType!);

            var updatedRequestBodyBytes = Encoding.UTF8.GetBytes(updatedRequestBody);

            updatedBody.Write(updatedRequestBodyBytes, 0, updatedRequestBodyBytes.Length);
            updatedBody.Seek(0, SeekOrigin.Begin);

            context.Request.ContentLength = updatedRequestBodyBytes.Length;
            
            await _next(context);
        }
        finally
        {
            context.Request.Body = originalBody;
        }
    }

    private static string GetJsonRequestWithTypes(string requestBody, string realityType, string dealType)
    {
        var jsonBody = JObject.Parse(requestBody);

        if(!jsonBody.ContainsKey("realityInfo") && !jsonBody.ContainsKey("dealInfo")) return requestBody;

        var jsonRealityInfo = jsonBody["realityInfo"] as JObject;
        jsonRealityInfo?.Add("realityType", realityType);

        var jsonDealInfo = jsonBody["dealInfo"] as JObject;
        jsonDealInfo?.Add("dealType", dealType);
        
        return jsonBody.ToString();
    }   
}