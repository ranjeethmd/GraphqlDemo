using GraphqlDemo.Common;
using GraphqlDemo.Data;
using System.Collections.Generic;

namespace GraphqlDemo.Tags
{
    public class AssignTagPayload : TagPayloadBase
    {
        public AssignTagPayload(Tag payload)
            : base(payload)
        {
        }

        public AssignTagPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public AssignTagPayload(UserError errors)
            : this(new[] { errors })
        {
        }
    }
}
