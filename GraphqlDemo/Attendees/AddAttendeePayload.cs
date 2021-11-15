using GraphqlDemo.Common;
using GraphqlDemo.Data;
using System.Collections.Generic;

namespace GraphqlDemo.Attendees
{
    public class AddAttendeePayload : AttendeePayloadBase
    {
        public AddAttendeePayload(Attendee attendee)
            : base(attendee)
        {
        }

        public AddAttendeePayload(IReadOnlyList<UserError>? errors = null)
            : base(errors)
        {
        }

        public AddAttendeePayload(UserError error)
            : this(new[] { error })
        {
        }
    }
}
