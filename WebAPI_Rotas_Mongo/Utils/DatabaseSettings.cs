namespace WebAPI_Rotas_Mongo.Utils
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string AnimalCollectionName { get; set; }
        public string PersonCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
