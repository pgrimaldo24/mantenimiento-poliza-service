using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace Interseguro.Mantenimiento.Poliza.Api.Installers.Filter
{
    public class SwaggerAuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var isAuthorized = context.MethodInfo.DeclaringType != null && context.MethodInfo.DeclaringType.GetCustomAttributes(true)
               .Union(context.MethodInfo.GetCustomAttributes(true))
               .OfType<AuthorizeAttribute>().Any();

            if (!isAuthorized) return;

            var allowAnonymousAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<AllowAnonymousAttribute>();

            if (!allowAnonymousAttributes.Any())
            {
                operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
                operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });

            } 

            //var authAttributes = context.MethodInfo
            //    .GetCustomAttributes(true)
            //    .OfType<AuthorizeAttribute>()
            //    .Select(attr => attr.Policy)
            //    .Distinct().ToList();
            //if (authAttributes.Any())
            //{
            var oAuthScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            };

            operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement
                    {
                        [ oAuthScheme ] = new string[]{}
                    }
                }; 
        }
         
    }
}
