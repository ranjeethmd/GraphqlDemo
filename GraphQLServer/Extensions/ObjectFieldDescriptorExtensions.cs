﻿using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphqlDemo.Extensions
{
    public static class ObjectFieldDescriptorExtensions
    {
        public static IObjectFieldDescriptor UseDbContext<TDbContext>(
            this IObjectFieldDescriptor descriptor)
            where TDbContext : DbContext
        {
            return descriptor.UseScopedService(
                create: s => s.GetRequiredService<IDbContextFactory<TDbContext>>().CreateDbContext(),
                disposeAsync: (s, c) => c.DisposeAsync());
        }

        public static IObjectFieldDescriptor UseUpperCase(
            this IObjectFieldDescriptor descriptor)
        {
            return descriptor.Use(next => async context =>
            {
                await next(context);

                if (context.Result is string s)
                {
                    context.Result = s.ToUpperInvariant();
                }
            });
        }
    }
}
