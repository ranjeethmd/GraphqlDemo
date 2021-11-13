using GraphqlDemo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDemo.Tags
{
    public class TagPayloadBase : Payload
    {
        protected TagPayloadBase(Payload payload)
        {
            Payload = payload;
        }
        protected TagPayloadBase(IReadOnlyList<UserError>? errors) : base(errors)
        {
        }

        public Payload? Payload { get; }
    }
}
