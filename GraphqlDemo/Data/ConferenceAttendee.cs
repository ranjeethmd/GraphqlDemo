namespace GraphqlDemo.Data
{
    public class ConferenceAttendee
    {
        public int ConfrenceId { get; set; }
        public int AttendeeID { get; set; }
        public Attendee? Attendee { get; set; }
        public Conference? Conference { get; set; }
    }
}