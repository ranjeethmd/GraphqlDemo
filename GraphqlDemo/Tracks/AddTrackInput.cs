using GraphqlDemo.Data;
using HotChocolate.Types.Relay;

namespace GraphqlDemo.Tracks
{

    public class AddTrackInput
    {
        [ID(nameof(Conference))]
        public int ConfrenceId { get; set; }
        public string Name { get; set; } = default!;

    }
}
