using GraphqlDemo.Common;
using GraphqlDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDemo.Conferences
{
    public class ConferencePayloadBase:Payload
    {
        protected ConferencePayloadBase(Conference conference)
        {
            Conference = conference;
        }

        protected ConferencePayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Conference? Conference { get; }
    }
}
