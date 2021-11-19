namespace GraphqlDemo.Data
{
    public class ConferenceAttendee
    {        
        public int AttendeeID { get; set; }
        public Attendee? Attendee { get; set; }
        public int ConferenceId { get; set; }
        public Conference? Conference { get; set; }
    }
}