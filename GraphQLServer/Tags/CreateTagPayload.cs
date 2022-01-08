using GraphqlDemo.Common;
using GraphqlDemo.Data;
using System.Collections.Generic;

namespace GraphqlDemo.Tags
{
    public class CreateTagPayload : TagPayloadBase
    {
        public CreateTagPayload(Tag payload)
            : base(payload)
        {
        }

        public CreateTagPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public CreateTagPayload(UserError errors)
            : this(new[] { errors })
        {
        }
    }
}
