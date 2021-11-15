using GraphqlDemo.Common;
using GraphqlDemo.Data;
using System.Collections.Generic;

namespace GraphqlDemo.Attendees
{
    public class RegisterAttendeePayload : AttendeePayloadBase
    {
        public RegisterAttendeePayload(Attendee attendee)
            : base(attendee)
        {
        }

        public RegisterAttendeePayload(IReadOnlyList<UserError>? errors = null)
            : base(errors)
        {
        }

        public RegisterAttendeePayload(UserError error)
            : this(new[] { error })
        {
        }
    }
}
