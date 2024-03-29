﻿using GraphqlDemo.Data;
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
    public class TrackType : ObjectType<Track>
    {
        protected override void Configure(IObjectTypeDescriptor<Track> descriptor)
        {
            descriptor
                .Authorize("CanReadGraph")
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) =>
                    ctx.DataLoader<TrackByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

            descriptor
                .Authorize("CanReadGraph")
                .Field(t => t.Sessions)
                .ResolveWith<TrackResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("sessions");

            descriptor
                .Authorize("CanReadGraph")
                .Field(t => t.Conference)
                .ResolveWith<TrackResolvers>(t => t.GetConferenceAsync(default!, default!, default))
                .Name("conference");

            descriptor
                .Authorize("CanReadGraph")
                .Field(t => t.ConferenceId)
                .ID(nameof(Conference));

        }

        private class TrackResolvers
        {
            public async Task<IEnumerable<Session>> GetSessionsAsync(
                [Parent] Track track,
                [ScopedService] ApplicationDbContext dbContext,
                SessionByIdDataLoader sessionById,
                CancellationToken cancellationToken)
            {
                int[] sessionIds = await dbContext.Sessions
                    .Where(s => s.Id == track.Id)
                    .Select(s => s.Id)
                    .ToArrayAsync();

                return await sessionById.LoadAsync(sessionIds, cancellationToken);
            }

            public async Task<Conference?> GetConferenceAsync(
                [Parent] Track track,
                ConferenceByIdDataLoader conferenceById,
                CancellationToken cancellationToken)
            {
                return await conferenceById.LoadAsync(track.ConferenceId, cancellationToken);
            }
        }
    }
}
