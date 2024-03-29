﻿using GraphqlDemo.Data;
using GraphqlDemo.Extensions;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using System.Threading;
using System.Threading.Tasks;

namespace GraphqlDemo.Tracks
{
    [ExtendObjectType("Mutation")]
    [Authorize(Policy = "CanWriteGraph")]
    public class TrackMutations
    {
        [UseApplicationDbContext]
        public async Task<AddTrackPayload> AddTrackAsync(
            AddTrackInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            var track = new Track
            {
                ConferenceId = input.ConfrenceId,
                Name = input.Name
            };

            context.Tracks.Add(track);

            await context.SaveChangesAsync(cancellationToken);

            return new AddTrackPayload(track);
        }

        [UseApplicationDbContext]
        public async Task<RenameTrackPayload> RenameTrackAsync(
        RenameTrackInput input,
        [ScopedService] ApplicationDbContext context,
        CancellationToken cancellationToken)
        {
            Track track = await context.Tracks.FindAsync(input.Id);
            track.Name = input.Name;

            await context.SaveChangesAsync(cancellationToken);

            return new RenameTrackPayload(track);
        }
    }
}
