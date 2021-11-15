using GraphqlDemo.Data;
using HotChocolate.Types.Relay;
using System.Collections.Generic;

namespace GraphqlDemo.Sessions
{
    public record AddSessionInput(
       string Title,
       string? Abstract,
       [ID(nameof(Speaker))]
       IReadOnlyList<int> SpeakerIds);
}
