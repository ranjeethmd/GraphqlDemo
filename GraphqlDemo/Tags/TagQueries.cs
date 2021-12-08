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

namespace GraphqlDemo.Tags
{
    [ExtendObjectType("Query")]
    public class TagQueries
    {
        [UseApplicationDbContext]
        public async Task<IEnumerable<Tag>> GetTagsAsync(
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken) =>
            await context.Tags.ToListAsync(cancellationToken);


        public Task<Tag> GetTagByIdAsync(
            [ID(nameof(Tag))] int id,
            TagByIdDataLoader tagById,
            CancellationToken cancellationToken) =>
            tagById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Tag>> GetTagByIdAsync(
            [ID(nameof(Tag))] int[] ids,
            TagByIdDataLoader tagById,
            CancellationToken cancellationToken) =>
            await tagById.LoadAsync(ids, cancellationToken);


        [UseApplicationDbContext]
        public async Task<Tag?> GetTagByNameAsync(
        string name,
        [ScopedService] ApplicationDbContext context)
        {
            return await context.Tags
            .FirstAsync(t => t.Name == name);
        }


        [UseApplicationDbContext]
        public async Task<IEnumerable<Tag>> GetTagByNamesAsync(
        string[] names,
        [ScopedService] ApplicationDbContext context)
        {
            return await context.Tags
            .Where(t => names.Contains(t.Name))
            .ToArrayAsync();

        }

    }
}
