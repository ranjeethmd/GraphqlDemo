using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDemo.Data
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public ICollection<SessionTag> SessionTags { get; set; } = new List<SessionTag>();
    }
}
