﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphqlDemo.Data
{
    public class Session
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Title { get; set; }

        [StringLength(4000)]
        public string? Abstract { get; set; }

        public DateTimeOffset? StartTime { get; set; }

        public DateTimeOffset? EndTime { get; set; }

        // Bonus points to those who can figure out why this is written this way
        public TimeSpan Duration =>
            EndTime?.Subtract(StartTime ?? EndTime ?? DateTimeOffset.MinValue) ??
                TimeSpan.Zero;

        public int? TrackId { get; set; }

        public int? ConferenceId { get; set; }

        public ICollection<SessionSpeaker> SessionSpeakers { get; set; } =
            new List<SessionSpeaker>();

        public ICollection<SessionAttendee> SessionAttendees { get; set; } =
            new List<SessionAttendee>();

        public ICollection<SessionTag> SessionTags { get; set; } =
            new List<SessionTag>();

        public Track? Track { get; set; }

        public Conference? Conference { get; set; }
    }
}
