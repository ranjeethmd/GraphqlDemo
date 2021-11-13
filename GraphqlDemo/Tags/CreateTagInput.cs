using GraphqlDemo.Data;
using HotChocolate.Types.Relay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDemo.Tags
{
    public record CreateTagInput
    (
         [ID(nameof(Tag))]
         string Name
    );
}
