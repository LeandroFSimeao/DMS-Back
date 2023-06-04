using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DMS.Models
{
    public class Item_pedido
    {
        [Key]
        [Required]
        public int IdItemPedido { get; set; }
        [Required]
        public int IdPedido { get; set; }
        [Required]
        public string Descricao { get; set; }
        public decimal Peso { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [JsonIgnore]
        public virtual Pedido Pedido { get; set; }

    }
}
