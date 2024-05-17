using System.ComponentModel.DataAnnotations;

namespace FesAragon.dotnet.Clientes.Api.Dtos
{
    public class ClienteDtoIn
    {
        [Required]
        [MaxLength(120)]
        public string Apellidos { get; set; }

        [Required]
        [MaxLength(50)]
        public string Correo { get; set; }

        [Required]
        public Guid Guid { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string Telefono { get; set; }

        [Required]
        public DireccionDto Direccion { get; set; }
    }

    public class ClienteDto : ClienteDtoIn
    {
        public int Id { get; set; }
    }
}