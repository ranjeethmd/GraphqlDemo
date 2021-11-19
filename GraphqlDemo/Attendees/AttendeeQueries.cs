using GraphqlDemo.Data;
using GraphqlDemo.DataLoader;
using GraphqlDemo.Extensions;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphqlDemo.Attendees
{
    [ExtendObjectType("Query")]
    public class AttendeeQueries
    {
        [UseApplicationDbContext]
        public async Task<IEnumerable<Attendee>> GetAttendeesAsync(
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken) =>
            await context.Attendees.ToListAsync(cancellationToken);


        public Task<Attendee> GetAttendeeByIdAsync(
            [ID(nameof(Attendee))] int id,
            AttendeeByIdDataLoader attendeeById,
            CancellationToken cancellationToken) =>
            attendeeById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Attendee>> GetAttendeeByIdAsync(
            [ID(nameof(Attendee))] int[] ids,
            AttendeeByIdDataLoader attendeeById,
            CancellationToken cancellationToken) =>
            await attendeeById.LoadAsync(ids, cancellationToken);

        [UseApplicationDbContext]
        public async Task<Attendee?> GetAttendeeByUserNameAsync(
        string name,
        [ScopedService] ApplicationDbContext context)
        {
            return await context.Attendees
            .FirstAsync(t => t.UserName == name);
        }

        [UseApplicationDbContext]
        public async Task<IEnumerable<Attendee>> GetAttendeeByUserNamesAsync(
        string[] names,
        [ScopedService] ApplicationDbContext context)
        {
            return await context.Attendees
            .Where(t => names.Contains(t.UserName))
            .ToArrayAsync();          

        }
    }
}

