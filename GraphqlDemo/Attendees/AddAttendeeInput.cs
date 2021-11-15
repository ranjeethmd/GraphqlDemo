namespace GraphqlDemo.Attendees
{
    public record AddAttendeeInput
    (
        string FirstName,
        string LastName,
        string UserName,
        string EmailAddress
    );
}
