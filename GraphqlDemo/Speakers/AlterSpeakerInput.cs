using GraphqlDemo.Data;
using HotChocolate.Types.Relay;

namespace GraphqlDemo.Records
{
    public record AlterSpeakerInput
    {
        [ID(nameof(Speaker))]
        public int Id { get; set; } = default!;
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string? WebSite { get; set; }
    }
}
