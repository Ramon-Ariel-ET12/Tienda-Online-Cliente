using Api.Funcionalidades.Categorias;
using Api.Persistencia;
using Aplicacion.Dominio;
namespace Api.Funcionalidades.Productos;

public interface IProductoService
{
    List<Producto> GetProductos();
}
public class ProductoService : IProductoService
{
    private readonly TiendaOnlineDbContext context;
    public ProductoService(TiendaOnlineDbContext context)
    {
        this.context = context;
    }
    public List<Producto> GetProductos()
    {
        return context.Productos.ToList();
    }
}