using GraphqlDemo.Data;
using HotChocolate.Types.Relay;

namespace GraphqlDemo.Tracks
{
    public record AddTrackInput(
        [ID(nameof(Conference))]
        int ConfrenceId,
        string Name);
}
