using GraphqlDemo.Common;
using GraphqlDemo.Data;
using System.Collections.Generic;

namespace GraphqlDemo.Conferences
{
    public class ConferencePayloadBase : Payload
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
