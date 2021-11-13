using GraphqlDemo.Data;
using HotChocolate.Types.Relay;

namespace GraphqlDemo.Tracks
{
    public record RenameTrackInput([ID(nameof(Track))] int Id, string Name);
}
