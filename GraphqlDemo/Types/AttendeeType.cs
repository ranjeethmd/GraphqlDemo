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
    public class AttendeeType : ObjectType<Attendee>
    {
        protected override void Configure(IObjectTypeDescriptor<Attendee> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<AttendeeByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

            descriptor
                .Field(t => t.SessionsAttendees)
                .ResolveWith<AttendeeResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("sessions");

            descriptor
                .Field(t => t.ConferenceAttendees)
                .ResolveWith<AttendeeResolvers>(t => t.GetConfrencesAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("conferences");
        }

        private class AttendeeResolvers
        {
            public async Task<IEnumerable<Session>> GetSessionsAsync(
                Attendee attendee,
                [ScopedService] ApplicationDbContext dbContext,
                SessionByIdDataLoader sessionById,
                CancellationToken cancellationToken)
            {
                int[] speakerIds = await dbContext.Attendees
                    .Where(a => a.Id == attendee.Id)
                    .Include(a => a.SessionsAttendees)
                    .SelectMany(a => a.SessionsAttendees.Select(t => t.SessionId))
                    .ToArrayAsync();

                return await sessionById.LoadAsync(speakerIds, cancellationToken);
            }
            public async Task<IEnumerable<Conference>> GetConfrencesAsync(
               Attendee attendee,
               [ScopedService] ApplicationDbContext dbContext,
               ConferenceByIdDataLoader conferenceById,
               CancellationToken cancellationToken)
            {
                int[] conferenceIds = await dbContext.Attendees
                    .Where(a => a.Id == attendee.Id)
                    .Include(a => a.ConferenceAttendees)
                    .SelectMany(a => a.ConferenceAttendees.Select(t => t.ConfrenceId))
                    .ToArrayAsync();

                return await conferenceById.LoadAsync(conferenceIds, cancellationToken);
            }
        }
    }
}
