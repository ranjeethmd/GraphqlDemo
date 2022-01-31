using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphqlDemo.Data
{
    public class Conference
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = default!;
        public ICollection<Session> Sessions { get; set; } = new List<Session>();

        public ICollection<Track> Tracks { get; set; } = new List<Track>();


        public ICollection<Speaker> Speakers { get; set; } = new List<Speaker>();

        public ICollection<ConferenceAttendee> ConferenceAttendees { get; set; } = new List<ConferenceAttendee>();

    }
}
