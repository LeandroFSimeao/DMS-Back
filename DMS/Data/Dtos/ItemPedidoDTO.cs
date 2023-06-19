namespace DMS.Data.Dtos
{
    public class ItemPedidoDTO
    {
        public int IdItemPedido { get; set; }
        public int IdPedido { get; set; }
        public string Descricao { get; set; }
        public decimal Peso { get; set; }
        public decimal Valor { get; set; }
    }
}
