﻿// <auto-generated />
using System;
using Api.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Persistencia.Migraciones
{
    [DbContext(typeof(TiendaOnlineDbContext))]
    [Migration("20231121174846_AddForeignKeyCarrito")]
    partial class AddForeignKeyCarrito
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Aplicacion.Dominio.Carrito", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<Guid?>("IdCliente")
                        .HasColumnType("char(36)");

                    b.Property<double>("Total")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.ToTable("Carrito");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Producto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("IdCategoria")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("IdProducto")
                        .HasColumnType("char(36)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdProducto");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Carrito", b =>
                {
                    b.HasOne("Aplicacion.Dominio.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Producto", b =>
                {
                    b.HasOne("Aplicacion.Dominio.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aplicacion.Dominio.Carrito", null)
                        .WithMany("Productos")
                        .HasForeignKey("IdProducto");

                    b.HasOne("Aplicacion.Dominio.Categoria", null)
                        .WithMany("productos")
                        .HasForeignKey("IdProducto");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Carrito", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Categoria", b =>
                {
                    b.Navigation("productos");
                });
#pragma warning restore 612, 618
        }
    }
}
