namespace DMS.Data.Dtos
{
    public class PedidoDTO
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public int? idEntrega { get; set; }
        public string Nf { get; set; }
        public string Entrega_ou_servico { get; set; }
        public string Status { get; set; }
        public decimal Valor { get; set; }
        public decimal Peso { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
