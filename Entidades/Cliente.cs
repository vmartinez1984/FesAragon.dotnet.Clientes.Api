using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Clientes.Api.Entidades
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }


        public string Apellidos { get; set; }


        public string Correo { get; set; }


        public int Id { get; set; }

        public string Guid { get; set; }


        public string Nombre { get; set; }


        public string Telefono { get; set; }


        public Direccion Direccion { get; set; }

    }
}