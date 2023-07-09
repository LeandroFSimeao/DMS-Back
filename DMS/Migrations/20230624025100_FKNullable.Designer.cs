﻿// <auto-generated />
using System;
using DMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DMS.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230624025100_FKNullable")]
    partial class FKNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DMS.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Latitude")
                        .HasColumnType("longtext");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Longitude")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("DMS.Models.Entrega", b =>
                {
                    b.Property<int>("IdEntrega")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Motorista")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Veiculo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdEntrega");

                    b.ToTable("Entregas");
                });

            modelBuilder.Entity("DMS.Models.Item_pedido", b =>
                {
                    b.Property<int>("IdItemPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("IdItemPedido");

                    b.HasIndex("IdPedido");

                    b.ToTable("ItensPedido");
                });

            modelBuilder.Entity("DMS.Models.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Entrega_ou_servico")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("Nf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("idEntrega")
                        .HasColumnType("int");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdCliente");

                    b.HasIndex("idEntrega");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("DMS.Models.Item_pedido", b =>
                {
                    b.HasOne("DMS.Models.Pedido", "Pedido")
                        .WithMany("Itens_Pedido")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("DMS.Models.Pedido", b =>
                {
                    b.HasOne("DMS.Models.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DMS.Models.Entrega", "Entrega")
                        .WithMany("Pedidos")
                        .HasForeignKey("idEntrega");

                    b.Navigation("Cliente");

                    b.Navigation("Entrega");
                });

            modelBuilder.Entity("DMS.Models.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("DMS.Models.Entrega", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("DMS.Models.Pedido", b =>
                {
                    b.Navigation("Itens_Pedido");
                });
#pragma warning restore 612, 618
        }
    }
}