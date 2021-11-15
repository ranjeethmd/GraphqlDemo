using GraphqlDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphqlDemo
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Attendee>()
                .HasIndex(a => a.UserName)
                .IsUnique();

            modelBuilder
               .Entity<Conference>()
               .HasIndex(a => a.Name)
               .IsUnique();

            modelBuilder
              .Entity<Tag>()
              .HasIndex(a => a.Name)
              .IsUnique();

            // Many-to-many: Session <-> Attendee
            modelBuilder
                .Entity<SessionAttendee>()
                .HasKey(ca => new { ca.SessionId, ca.AttendeeId });

            // Many-to-many: Speaker <-> Session
            modelBuilder
                .Entity<SessionSpeaker>()
                .HasKey(ss => new { ss.SessionId, ss.SpeakerId });

            // Many-to-many: Session <-> Tag
            modelBuilder
                .Entity<SessionTag>()
                .HasKey(st => new { st.SessionId, st.TagId });

            // Many-to-many: Conference <-> Attendee
            modelBuilder
                .Entity<ConferenceAttendee>()
                .HasKey(ca => new { ca.ConfrenceId, ca.AttendeeID });
        }

        public DbSet<Conference> Conferences { get; set; } = default!;

        public DbSet<Session> Sessions { get; set; } = default!;

        public DbSet<Track> Tracks { get; set; } = default!;

        public DbSet<Speaker> Speakers { get; set; } = default!;

        public DbSet<Attendee> Attendees { get; set; } = default!;

        public DbSet<Tag> Tags { get; set; } = default!;
    }
}
