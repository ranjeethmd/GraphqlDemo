using GraphqlDemo.Data;
using HotChocolate.Types.Relay;
using System.Collections.Generic;

namespace GraphqlDemo.Sessions
{
    public class AddSessionInput
    {
        public string Title { get; set; } = default!;
        public string? Abstract { get; set; }
        [ID(nameof(Speaker))]
        public IReadOnlyList<int> SpeakerIds { get; set; } = default!;
    }
}
