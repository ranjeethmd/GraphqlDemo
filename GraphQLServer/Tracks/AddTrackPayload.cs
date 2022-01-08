using GraphqlDemo.Common;
using GraphqlDemo.Data;
using System.Collections.Generic;

namespace GraphqlDemo.Tracks
{
    public class AddTrackPayload : TrackPayloadBase
    {
        public AddTrackPayload(Track track)
            : base(track)
        {
        }

        public AddTrackPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
