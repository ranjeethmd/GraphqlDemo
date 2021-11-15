using GraphqlDemo.Common;
using GraphqlDemo.Conferences;
using GraphqlDemo.Data;
using GraphqlDemo.Extensions;
using HotChocolate;
using HotChocolate.Types;
using System.Threading;
using System.Threading.Tasks;

namespace GraphqlDemo.Tags
{
    [ExtendObjectType("Mutation")]
    public class TagMutations
    {
        [UseApplicationDbContext]
        public async Task<CreateTagPayload> CreateTagAsync(
           CreateTagInput  input,
           [ScopedService] ApplicationDbContext context,
           CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(input.Name))
            {
                return new CreateTagPayload(
                    new UserError("The name cannot be empty.", "TITLE_EMPTY"));
            }


            var tag = new Tag
            {
                Name = input.Name
            };

            context.Tags.Add(tag);
            await context.SaveChangesAsync(cancellationToken);

            return new CreateTagPayload(tag);
        }

        [UseApplicationDbContext]
        public async Task<CreateTagPayload> AssignTagAsync(
           AssignTagInput input,
           [ScopedService] ApplicationDbContext context,
           CancellationToken cancellationToken)
        {
            var tag = await context.Tags.FindAsync(input.Id);

            foreach(int sessionId in input.SessionIds)
            {
                tag.SessionTags.Add(new SessionTag { 
                    TagId=input.Id,
                    SessionId = sessionId
                });
            }           

          
            await context.SaveChangesAsync(cancellationToken);

            return new CreateTagPayload(tag);
        }
    }
}
