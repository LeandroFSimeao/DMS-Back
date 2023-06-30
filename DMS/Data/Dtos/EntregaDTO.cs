using System.Numerics;

namespace DMS.Data.Dtos
{
    public class EntregaDTO
    {
        public int IdEntrega { get; set; }
        public string Motorista { get; set; }
        public string Veiculo { get; set; }
        public string Polyline { get; set; }
        public int Duracao { get; set; }
        public int Distancia { get; set; }
    }
}
