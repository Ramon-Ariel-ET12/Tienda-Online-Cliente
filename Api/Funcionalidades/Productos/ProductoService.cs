using Api.Funcionalidades.Categorias;
using Api.Persistencia;
using Aplicacion.Dominio;
namespace Api.Funcionalidades.Productos;

public interface IProductoService
{
    void Createproducto(ProductoCommandDto productoDto, Guid idcategoria);
    void Deleteproducto(Guid productoid);
    List<ProductoQueryDto> GetProductos();
    void Updateproducto(Guid productoId, ProductoCommandDto productoDto);
}
public class ProductoService : IProductoService
{
    private readonly TiendaOnlineDbContext context;

    public ProductoService(TiendaOnlineDbContext context)
    {
        this.context = context;
    }


    public void Createproducto(ProductoCommandDto productoDto, Guid idcategoria)
    {
        var categoria = context.Categorias.FirstOrDefault(x => x.Id == idcategoria);
        context.Productos.Add(new Producto(categoria, productoDto.Nombre, productoDto.Precio, productoDto.Descripcion, productoDto.Stock));
        context.SaveChanges();
    }

    public void Deleteproducto(Guid productoid)
    {
        var producto = context.Productos.FirstOrDefault(x => x.Id == productoid);
        if (producto != null)
        {
            context.Remove(producto);
            context.SaveChanges();
        }
    }

    public List<ProductoQueryDto> GetProductos()
    {
        return context.Productos.Select(x => new ProductoQueryDto { Id = x.Id, Nombre = x.Nombre, Precio = x.Precio, Stock = x.Stock }).ToList();
    }

    public void Updateproducto(Guid productoid, ProductoCommandDto productoDto)
    {
        var producto = context.Productos.FirstOrDefault(x => x.Id == productoid);
        if (producto != null)
        {
            producto.Nombre = productoDto.Nombre;
            producto.Precio = producto.Precio;
            producto.Stock = producto.Stock;
            context.SaveChanges();
        }

    }
}