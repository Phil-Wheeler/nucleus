using Microsoft.Extensions.Options;
using NucleusApi.Models;
using MongoDB.Driver;

namespace NucleusApi.Data
{
    public class ApiContext
    {
        private readonly IMongoDatabase _database = null;

        public ApiContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(options.Value.Database);
            }
        }

        public IMongoCollection<Post> Posts => _database.GetCollection<Post>("Posts");
    }
}