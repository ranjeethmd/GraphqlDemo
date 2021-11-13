using GraphqlDemo.Common;
using GraphqlDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDemo.Conferences
{
    public class CreateConferencePayload : ConferencePayloadBase
    {
        public CreateConferencePayload(Conference conference) : base(conference)
        {
        }

        public CreateConferencePayload(IReadOnlyList<UserError> errors) : base(errors)
        {
        }

        public CreateConferencePayload(UserError errors) : this(new[] { errors })
        {
        }
    }
}
