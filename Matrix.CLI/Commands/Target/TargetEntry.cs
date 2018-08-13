using LiteDB;

namespace Matrix.CLI.Commands.Target
{
    public class TargetEntry
    {
        [BsonId]
        public string Alias { get; set; }

        public string Url { get; set; }
    }
}