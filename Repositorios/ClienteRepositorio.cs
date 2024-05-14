using Clientes.Api.Entidades;
using MongoDB.Driver;

namespace Clientes.Api.Repositorios
{
    public class ClienteRepositorio
    {
        private readonly IMongoCollection<Cliente> _collection;
        public ClienteRepositorio(IConfiguration configurations)
        {
            var mongoClient = new MongoClient(
                configurations.GetConnectionString("mongoDbGastos")
            );
            var nombreDeLaDb = configurations.GetSection("mongoDbNombre").Value;
            var mongoDatabase = mongoClient.GetDatabase(nombreDeLaDb);
            _collection = mongoDatabase.GetCollection<Cliente>("Clientes");
        }              

        internal async Task<int> AgregarAsync(Cliente item)
        {
            item.Id = ((int)await _collection.CountDocumentsAsync(_ => true)) + 1;
            await _collection.InsertOneAsync(item);

            return item.Id;
        }

        internal async Task<List<Cliente>> ObtenerTodosAsync()
        {
            var clientes = await _collection.Find(_ => true).ToListAsync();

            return clientes;
        }
    }
}