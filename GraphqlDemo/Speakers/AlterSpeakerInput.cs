using GraphqlDemo.Data;
using HotChocolate.Types.Relay;

namespace GraphqlDemo.Records
{
    public record AlterSpeakerInput(
        [ID(nameof(Speaker))] int Id,
        string? Name,
        string? Bio,
        string? WebSite);
}
