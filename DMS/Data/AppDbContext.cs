using DMS.Models;
using Microsoft.EntityFrameworkCore;

namespace DMS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base (opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Item_pedido>()
                .HasOne(item_pedido => item_pedido.Pedido)
                .WithMany(pedido => pedido.Itens_Pedido)
                .HasForeignKey(item_pedido => item_pedido.IdPedido);

            builder.Entity<Pedido>()
                .HasOne(pedido => pedido.C)
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<Item_pedido> ItensPedido { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
