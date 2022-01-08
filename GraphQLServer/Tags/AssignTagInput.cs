using GraphqlDemo.Data;
using HotChocolate.Types.Relay;
using System.Collections.Generic;

namespace GraphqlDemo.Tags
{
    public class AssignTagInput
    {
        [ID(nameof(Tag))]
        public int Id { get; set; } = default!;

        [ID(nameof(Session))]
        public IReadOnlyList<int> SessionIds { get; set; } = default!;
    }
}
