using Aplicacion.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Api.Persistencia;
public class TiendaOnlineDbContext : DbContext
{
    public TiendaOnlineDbContext(DbContextOptions<TiendaOnlineDbContext> opciones) : base (opciones)
    {
        
    }

    public DbSet<Categoria> Categorias { get; set ;}
    public DbSet<Producto> Productos { get; set ;}
    public DbSet<Carrito> Carritos { get; set ;}
    public DbSet<Cliente> Clientes { get; set ;}
}