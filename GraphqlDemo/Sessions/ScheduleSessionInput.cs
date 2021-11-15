using GraphqlDemo.Data;
using HotChocolate.Types.Relay;
using System;

namespace GraphqlDemo.Sessions
{
    public record ScheduleSessionInput
    {
        [ID(nameof(Session))]
        public int SessionId{get; set;} = default!;
        [ID(nameof(Track))]
        public int TrackId { get; set; } = default!;
        [ID(nameof(Conference))]
        public int ConferenceId { get; set; } = default!;
        public DateTimeOffset StartTime { get; set; } = default!;
        public DateTimeOffset EndTime { get; set; } = default!;
    }
}
