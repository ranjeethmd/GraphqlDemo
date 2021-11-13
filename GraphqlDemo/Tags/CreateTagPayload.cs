using GraphqlDemo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDemo.Tags
{
    public class CreateTagPayload : TagPayloadBase
    {
        protected CreateTagPayload(Payload payload) 
            : base(payload)
        {
        }

        protected CreateTagPayload(IReadOnlyList<UserError> errors) 
            : base(errors)
        {
        }

        protected CreateTagPayload(UserError errors)
            : this(new[] { errors })
        {
        }
    }
}
