using GraphqlDemo.Common;
using GraphqlDemo.Data;
using GraphqlDemo.Extensions;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphqlDemo.Attendees
{
    [ExtendObjectType("Mutation")]
    public class AttendeeMutations
    {
        [UseApplicationDbContext]
        public async Task<AddAttendeePayload> AddAttendeeAsync(
            AddAttendeeInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(input.EmailAddress))
            {
                return new AddAttendeePayload(
                    new UserError("The email cannot be empty.", "EMAIL_EMPTY"));
            }

            if (string.IsNullOrEmpty(input.FirstName))
            {
                return new AddAttendeePayload(
                    new UserError("The first name cannot be empty.", "FIRST_EMPTY"));
            }

            if (string.IsNullOrEmpty(input.LastName))
            {
                return new AddAttendeePayload(
                    new UserError("The last name cannot be empty.", "LASTNAME_EMPTY"));
            }

            if (string.IsNullOrEmpty(input.UserName))
            {
                return new AddAttendeePayload(
                    new UserError("The username cannot be empty.", "USERNAME_EMPTY"));
            }

            var attendee = new Attendee
            {
                EmailAddress = input.EmailAddress,
                FirstName = input.FirstName,
                LastName = input.LastName,
                UserName = input.UserName
            };



            context.Attendees.Add(attendee);
            await context.SaveChangesAsync(cancellationToken);

            return new AddAttendeePayload(attendee);
        }


        [UseApplicationDbContext]
        public async Task<RegisterAttendeePayload> RegisterAttendeeAsync(
        RegisterAttendeeInput input,
        [ScopedService] ApplicationDbContext context)
        {
            
            var attendee = await context.Attendees.FindAsync(input.AttendeeId);

            if (attendee == null)
            {
                return new RegisterAttendeePayload(
                   new UserError("Attendee not found", "NO_ATTENDEE_FOUND"));
            }
           

            attendee.ConferenceAttendees.Add(new ConferenceAttendee {   
                AttendeeID = input.AttendeeId,
                ConferenceId = input.ConferenceId
            
            });

            foreach (var sessionId in input.SessionIds)
            {
                attendee.SessionsAttendees.Add(new SessionAttendee
                {
                    AttendeeId = input.AttendeeId,
                    SessionId = sessionId
                });
            }




            await context.SaveChangesAsync();

            return new RegisterAttendeePayload(attendee);
        }
    }
}
