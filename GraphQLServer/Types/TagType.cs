using GraphqlDemo.Data;
using GraphqlDemo.DataLoader;
using GraphqlDemo.Extensions;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphqlDemo.Types
{
    public class TagType : ObjectType<Tag>
    {
        protected override void Configure(IObjectTypeDescriptor<Tag> descriptor)
        {
            descriptor
                .Authorize("CanReadGraph")
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<TagByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

            descriptor
                .Authorize("CanReadGraph")
                .Field(t => t.SessionTags)
                .ResolveWith<TagResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("sessions");
        }

        private class TagResolvers
        {
            public async Task<IEnumerable<Session?>?> GetSessionsAsync(
                [Parent] Tag tag,
                [ScopedService] ApplicationDbContext dbContext,
                SessionByIdDataLoader sessionById,
                CancellationToken cancellationToken)
            {
                int[] sessionIds = await dbContext.Tags
                    .Where(t => t.Id == tag.Id)
                    .Include(t => t.SessionTags)
                    .SelectMany(s => s.SessionTags.Select(s => s.SessionId))
                    .ToArrayAsync();

                return await sessionById.LoadAsync(sessionIds, cancellationToken);
            }
        }
    }
}
