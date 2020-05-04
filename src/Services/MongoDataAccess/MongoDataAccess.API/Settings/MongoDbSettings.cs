namespace MongoDataAccess.API.Settings
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string Database { get; set; }
        public string Host { get; set; }
        public long Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Password))
                {
                    return $@"mongodb://{Host}:{Port}";
                }

                return $@"mongodb://{User}:{Password}@{Host}:{Port}";
            }
        }
    }

    public interface IMongoDbSettings
    {
        string Database { get; set; }
        long Port { get; set; }
        string Host { get; set; }
        string User { get; set; }
        string Password { get; set; }
        string ConnectionString { get; }
    }
}