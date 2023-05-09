namespace DMS.Models
{
    public class Item_pedido
    {
        public int IdItemPedido { get; set; }
        public int IdPedido { get; set; }
        public virtual Pedido Pedido { get; set; }

    }
}
