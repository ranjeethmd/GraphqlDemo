using GraphqlDemo.Data;
using HotChocolate.Types.Relay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDemo.Sessions
{
    public record AddSessionInput(
       string Title,
       string? Abstract,
       [ID(nameof(Speaker))]
        IReadOnlyList<int> SpeakerIds);
}
