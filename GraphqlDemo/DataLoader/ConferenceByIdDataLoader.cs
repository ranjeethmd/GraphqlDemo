using GraphqlDemo.Data;
using GreenDonut;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphqlDemo.DataLoader
{
    public class ConferenceByIdDataLoader : BatchDataLoader<int, Conference>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public ConferenceByIdDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<ApplicationDbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }
        protected override async Task<IReadOnlyDictionary<int, Conference>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            await using ApplicationDbContext dbContext =
               _dbContextFactory.CreateDbContext();

            return await dbContext.Conferences
               .Where(s => keys.Contains(s.Id))
               .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
