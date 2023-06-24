using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DMS.Models
{
    public class Pedido
    {
        [Key]
        [Required]
        public int IdPedido { get; set; }
        [Required]
        public int IdCliente { get; set; }
        public int? idEntrega { get; set; }
        [Required]
        public string Nf { get; set; }
        [Required]
        public string Entrega_ou_servico { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public decimal Peso { get; set; }
        [Required]
        public DateTime DataPedido { get; set; }
        [JsonIgnore]
        public virtual List<Item_pedido> Itens_Pedido { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Entrega Entrega { get; set; }
    }
}
