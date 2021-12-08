using Microsoft.AspNetCore.Builder;
using System;
using System.Linq;
using System.Security.Claims;

namespace GraphqlDemo.Extensions
{
    /// <summary>
    /// Middleware written to split claims if they exists
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        public static void SplitClaims(this IApplicationBuilder app, string type)
        {
            app.Use(async (context, next) =>
            {

                var claim = context.User.Claims.FirstOrDefault(c => c.Type == type);

                var claims = claim?.Value?.Split(' ', StringSplitOptions.RemoveEmptyEntries) ?? new string[0];

                if (claims.Length > 1)
                {

                    if (context.User.Identity is ClaimsIdentity identity)
                    {
                        identity.RemoveClaim(claim);

                        identity.AddClaims(claims.Select(c => new Claim(type, c)));
                    }
                }

                await next.Invoke();

            });

        }
    }
}
