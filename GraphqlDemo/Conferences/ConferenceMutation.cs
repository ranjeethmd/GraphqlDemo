using GraphqlDemo.Common;
using GraphqlDemo.Data;
using GraphqlDemo.Extensions;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphqlDemo.Conferences
{
    [ExtendObjectType("Mutation")]
    public class ConferenceMutation
    {
        [UseApplicationDbContext]
        public async Task<CreateConferencePayload> AddSessionAsync(
           CreateConferenceInput input,
           [ScopedService] ApplicationDbContext context,
           CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(input.Name))
            {
                return new CreateConferencePayload(
                    new UserError("The name cannot be empty.", "TITLE_EMPTY"));
            }


            var conference = new Conference
            {
                Name=input.Name
            };           

            context.Conferences.Add(conference);
            await context.SaveChangesAsync(cancellationToken);

            return new CreateConferencePayload(conference);
        }

    }
}
