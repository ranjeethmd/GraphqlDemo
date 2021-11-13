using GraphqlDemo.Data;
using HotChocolate.Types.Relay;


namespace GraphqlDemo.Conferences
{
    public record CreateConferenceInput(       
        string Name
    );
}
