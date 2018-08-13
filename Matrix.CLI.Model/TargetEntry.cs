using LiteDB;

namespace Matrix.CLI.Model
{
    public class TargetEntry
    {
        [BsonId]
        public string Alias { get; set; }

        public string Url { get; set; }
    }
}