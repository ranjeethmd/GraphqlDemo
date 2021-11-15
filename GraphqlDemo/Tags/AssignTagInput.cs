using GraphqlDemo.Data;
using HotChocolate.Types.Relay;
using System.Collections.Generic;

namespace GraphqlDemo.Tags
{
    public record AssignTagInput
    (
         [ID(nameof(Tag))]
         int Id,
         [ID(nameof(Session))]
         IReadOnlyList<int> SessionIds
    );
}
