using GraphqlDemo.Common;
using GraphqlDemo.Data;
using System.Collections.Generic;

namespace GraphqlDemo.Tracks
{
    public class TrackPayloadBase : Payload
    {
        public TrackPayloadBase(Track track)
        {
            Track = track;
        }

        public TrackPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Track? Track { get; }
    }
}
