using GraphqlDemo.Data;
using HotChocolate.Types.Relay;

namespace GraphqlDemo.Tracks
{
    public class RenameTrackInput
    {
        [ID(nameof(Track))]
        public int Id { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}
