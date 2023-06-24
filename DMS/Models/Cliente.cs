using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DMS.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public int Numero { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        [JsonIgnore]
        public virtual List<Pedido> Pedidos { get; set; }
    }
}
