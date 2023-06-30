using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace DMS.Models
{
    public class Entrega
    {
        [Key]
        [Required]
        public int IdEntrega { get; set; }
        [Required]
        public string Motorista { get; set; }
        [Required]
        public string Veiculo { get; set; }
        public string Polyline { get; set; }
        public int Duracao { get; set; }
        public int Distancia { get; set; }
        [JsonIgnore]
        public virtual List<Pedido> Pedidos { get; set; }
    }
}
