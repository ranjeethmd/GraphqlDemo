using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GraphqlDemo.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void SplitClaims(this IApplicationBuilder app, string type)
        {
            app.Use(async (context, next) =>
            {

                var claim = context.User.Claims.FirstOrDefault(c => c.Type == type);

                if(claim != null)
                {
                    var claims = claim.Value?.Split(' ', StringSplitOptions.RemoveEmptyEntries) ?? new string[0];

                    if(claims.Length > 1)
                    {
                        var identity = context.User.Identity as ClaimsIdentity;

                        if (identity != null)
                        {
                            identity.RemoveClaim(claim);

                            identity.AddClaims(claims.Select(c => new Claim(type, c)));
                        }
                    }

                    Console.WriteLine(claim.Value);
                }

                await next.Invoke();

            });

        }
    }
}
