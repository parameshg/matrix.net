namespace Matrix.Agent.Journal.Database.Converters
{
    public class LogEntryConverter
    {
        public Model.LogEntry ConvertToModel(Entities.LogEntry entity)
        {
            var result = new Model.LogEntry();

            return result;
        }

        public Entities.LogEntry ConvertToEntity(Model.LogEntry model)
        {
            var result = new Entities.LogEntry();

            return result;
        }
    }
}