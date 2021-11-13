using GraphqlDemo.Data;
using GraphqlDemo.Extensions;
using GraphqlDemo.Records;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphqlDemo
{
    [ExtendObjectType("Mutation")]
    public class SpeakerMutations
    {
        [UseApplicationDbContext]
        public async Task<AddSpeakerPayload> AddSpeakerAsync(
            AddSpeakerInput input,
            [ScopedService] ApplicationDbContext context)
        {
            var speaker = new Speaker
            {
                Name = input.Name,
                Bio = input.Bio,
                WebSite = input.WebSite
            };

            context.Speakers.Add(speaker);
            await context.SaveChangesAsync();

            return new AddSpeakerPayload(speaker);
        }

        [UseApplicationDbContext]
        public async Task<AddSpeakerPayload> AlterSpeakerAsync(
            AlterSpeakerInput input,
            [ScopedService] ApplicationDbContext context
            ,CancellationToken cancellationToken)
        {           

            var speaker= await context.Speakers.FindAsync(input.Id);


            
            await context.SaveChangesAsync(cancellationToken);

            return new AddSpeakerPayload(speaker);
        }
    }
}
