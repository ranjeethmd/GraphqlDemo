using GraphqlDemo.Data;
using HotChocolate.Types.Relay;
using System;

namespace GraphqlDemo.Sessions
{
    public record ScheduleSessionInput(
        [ID(nameof(Session))]
        int SessionId,
        [ID(nameof(Track))]
        int TrackId,
        [ID(nameof(Conference))]
        int ConferenceId,
        DateTimeOffset StartTime,
        DateTimeOffset EndTime);
}
