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
    public class SpeakerType : ObjectType<Speaker>
    {
        protected override void Configure(IObjectTypeDescriptor<Speaker> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<SpeakerByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));


            descriptor
                .Field(t => t.SessionSpeakers)
                .ResolveWith<SpeakerResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("sessions");
        }

        private class SpeakerResolvers
        {
            public async Task<IEnumerable<Session?>?> GetSessionsAsync(
                Speaker speaker,
                [ScopedService] ApplicationDbContext dbContext,
                SessionByIdDataLoader sessionById,
                CancellationToken cancellationToken)
            {
                int[] sessionIds = await dbContext.Speakers
                    .Where(s => s.Id == speaker.Id)
                    .Include(s => s.SessionSpeakers)
                    .SelectMany(s => s.SessionSpeakers.Select(t => t.SessionId))
                    .ToArrayAsync();

                return await sessionById.LoadAsync(sessionIds, cancellationToken);
            }
        }
    }
}
