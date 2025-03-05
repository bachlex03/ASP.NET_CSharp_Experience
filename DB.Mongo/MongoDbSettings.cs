namespace DB.Mongo;

public class MongoDbSettings
{
    public const string SettingKey = "MongoDbSettings";

    public string ConnectionString { get; set; } = default!;
    public string DatabaseName { get; set; } = default!;
}
