using GraphqlDemo.Data;
using HotChocolate.Types.Relay;
using System.Collections.Generic;

namespace GraphqlDemo.Attendees
{
    public record RegisterAttendeeInput
    (
        [ID(nameof(Attendee))]
        int AttendeeId,
        [ID(nameof(Conference))]
        int ConferenceId,
        [ID(nameof(Session))]
        IReadOnlyList<int> SessionIds
    );
}
