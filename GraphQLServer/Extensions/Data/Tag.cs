using System.Collections.Generic;

namespace GraphqlDemo.Data
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public ICollection<SessionTag> SessionTags { get; set; } = new List<SessionTag>();
    }
}
