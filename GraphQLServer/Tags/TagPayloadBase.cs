﻿using GraphqlDemo.Common;
using GraphqlDemo.Data;
using System.Collections.Generic;

namespace GraphqlDemo.Tags
{
    public class TagPayloadBase : Payload
    {
        protected TagPayloadBase(Tag payload)
        {
            Tag = payload;
        }
        protected TagPayloadBase(IReadOnlyList<UserError>? errors) : base(errors)
        {
        }

        public Tag? Tag { get; }
    }
}
