namespace Matrix.Agent.Directory.Database.Converters
{
    public class UserConverter
    {
        public Model.User ConvertToModel(Entities.User entity)
        {
            var result = new Model.User();

            return result;
        }

        public Entities.User ConvertToEntity(Model.User model)
        {
            var result = new Entities.User();

            return result;
        }
    }
}