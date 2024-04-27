using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace t.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Nome")]
        public required string NomeUsuario { get; set; }

        public required string Email { get; set; }

        public required string Senha { get; set; }

    }
}
