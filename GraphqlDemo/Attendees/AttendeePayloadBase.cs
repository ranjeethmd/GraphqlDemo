using GraphqlDemo.Common;
using GraphqlDemo.Data;
using System.Collections.Generic;

namespace GraphqlDemo.Attendees
{
    public class AttendeePayloadBase : Payload
    {
        public Attendee? Attendee { get; }

        protected AttendeePayloadBase(Attendee attendee)
        {
            Attendee = attendee;
        }

        public AttendeePayloadBase(IReadOnlyList<UserError>? errors = null)
            : base(errors)
        {
        }
    }
}
