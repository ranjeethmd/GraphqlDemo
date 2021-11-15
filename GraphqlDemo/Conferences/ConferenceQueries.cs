using GraphqlDemo.Data;
using GraphqlDemo.DataLoader;
using GraphqlDemo.Extensions;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphqlDemo.Conferences
{
    [ExtendObjectType("Query")]
    public class ConferenceQueries
    {
        [UseApplicationDbContext]
        public async Task<IEnumerable<Conference>> GetConferencesAsync(
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken) =>
            await context.Conferences.ToListAsync(cancellationToken);

        public Task<Conference> GetConferenceByIdAsync(
            [ID(nameof(Conference))] int id,
            ConferenceByIdDataLoader conferenceById,
            CancellationToken cancellationToken) =>
            conferenceById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Conference>> GetConferenceByIdAsync(
            [ID(nameof(Conference))] int[] ids,
            ConferenceByIdDataLoader conferenceById,
            CancellationToken cancellationToken) =>
            await conferenceById.LoadAsync(ids, cancellationToken);

        [UseApplicationDbContext]
        public async Task<Conference> GetConfrenceByNameAsync(
        string name,
        [ScopedService] ApplicationDbContext context)
        {
            return await context.Conferences
            .FirstAsync(c => c.Name == name);
        }

        [UseApplicationDbContext]
        public async Task<IEnumerable<Conference>> GetConfrenceByNamesAsync(
        string[] names,
        [ScopedService] ApplicationDbContext context)
        {
            return await context.Conferences
            .Where(t => names.Contains(t.Name))
            .ToArrayAsync();
        }
    }
}
