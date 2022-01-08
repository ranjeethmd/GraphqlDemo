using GraphqlDemo.Data;
using HotChocolate.Types.Relay;
using System.Collections.Generic;

namespace GraphqlDemo.Attendees
{
    public class RegisterAttendeeInput
    {
        [ID(nameof(Attendee))]
        public int AttendeeId { get; set; } = default!;
        [ID(nameof(Conference))]
        public int ConferenceId { get; set; } = default!;
        [ID(nameof(Session))]
        public IReadOnlyList<int> SessionIds { get; set; } = default!;
    }
}
