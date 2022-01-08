using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphqlDemo.Data
{
    public class Track
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Name { get; set; }

        public int ConferenceId { get; set; }

        public ICollection<Session> Sessions { get; set; } =
            new List<Session>();

        public Conference? Conference { get; set; }
    }
}
