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

namespace GraphqlDemo
{
    [ExtendObjectType("Query")]
    public class SpeakerQueries
    {
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakersAsync([ScopedService] ApplicationDbContext context) =>
            context.Speakers.ToListAsync();

        [UseApplicationDbContext]
        public Task<Speaker> GetSpeakerByNameAsync(string name,[ScopedService] ApplicationDbContext context) =>
            context.Speakers.FirstAsync(s => s.Name == name);

        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakerByNamesAsync(string[] names, [ScopedService] ApplicationDbContext context) =>
            context.Speakers.Where(s => names.Contains(s.Name)).ToListAsync();

        public Task<Speaker> GetSpeakerAsync(
            [ID(nameof(Speaker))] int id,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);
        public async Task<IEnumerable<Speaker>> GetSpeakersByIdAsync(
           [ID(nameof(Speaker))] int[] ids,
           SpeakerByIdDataLoader dataLoader,
           CancellationToken cancellationToken) =>
           await dataLoader.LoadAsync(ids, cancellationToken);
    }
}
