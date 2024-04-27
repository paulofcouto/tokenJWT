using Microsoft.Extensions.Options;
using MongoDB.Driver;
using t.Models;

namespace t.Services
{
    public class UsuarioService
    {
        private readonly IMongoCollection<Usuario> _context;
        static string _nameCollection = "Usuario";

        public UsuarioService(IOptions<DatabaseSettings> DatabaseSettings)
        {
            var mongoClient = new MongoClient(DatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(DatabaseSettings.Value.DatabaseName);

            _context = mongoDatabase.GetCollection<Usuario>(_nameCollection);
        }

        public Usuario ObterUsuario(string usuario, string senha)
        {
            return _context.Find(x => x.NomeUsuario == usuario && x.Senha == senha).SingleOrDefault();
        }

        public List<Usuario> ObterUsuarios()
        {
            return _context.Find(_ => true).ToList();
        }
    }
}
