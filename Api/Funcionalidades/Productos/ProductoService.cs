using Api.Funcionalidades.Categorias;
using Aplicacion.Dominio;
namespace Api.Funcionalidades.Productos;

public interface IProductoService
{
    List<Producto> GetProductos();
}
public class ProductoService : IProductoService
{
    List<Producto> productos;
    public ProductoService(ICategoriaService categoriaService)
    {
        List<Categoria> categorias = categoriaService.GetCategorias();
        productos = new List<Producto>()
        {
            new Producto("Pelota de futbol", "Para jugar al fulvo", 10, 90),
            new Producto("Peluche de messi", "Peluche del goat", 10, 100),
            new Producto("Pelota de basket", "Pertenecia a michael jordan", 10, 10)
        };
}
    public List<Producto> GetProductos()
    {
        return productos;
    }
}