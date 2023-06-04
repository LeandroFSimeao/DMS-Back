using System.ComponentModel.DataAnnotations;

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
    }
}
