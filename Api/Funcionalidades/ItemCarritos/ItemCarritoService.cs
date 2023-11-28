using Api.Funcionalidades.Productos;
using Api.Persistencia;
using Aplicacion.Dominio;

namespace Api.Funcionalidades.ItemCarritos;

public interface IItemCarritoService
{
    void CreateItemCarritos(ItemCarritoCommandDto2 itemCarrito, Guid idcarrito);
    void DeleteItemCarritos(Guid iditemcarrito);
    List<ItemCarritoQueryDto> GetItemCarritos();
    void UpdateItemCarritos(Guid iditemcarrito, ItemCarritoCommandDto itemCarrito, Guid IdProducto);
}
public class ItemCarritoService : IItemCarritoService
{
    private readonly TiendaOnlineDbContext context;
    public ItemCarritoService(TiendaOnlineDbContext context)
    {

        this.context = context;

    }

    public void CreateItemCarritos(ItemCarritoCommandDto2 itemCarrito, Guid idcarrito)
    {
        var carrito = context.Carritos.FirstOrDefault(x => x.Id == idcarrito);
        context.ItemCarritos.Add(new ItemCarrito(carrito));
        context.SaveChanges();
    }

    public void DeleteItemCarritos(Guid iditemcarrito)
    {
        var itemCarrito = context.ItemCarritos.FirstOrDefault(x => x.IdItemCarrito == iditemcarrito);
        if (itemCarrito != null)
        {
            context.Remove(itemCarrito);
            context.SaveChanges();
        }
    }

    public List<ItemCarritoQueryDto> GetItemCarritos()
    {
        return context.ItemCarritos.Select(x => new ItemCarritoQueryDto
        {
            IdItemCarrito = x.IdItemCarrito,
            Producto = new ProductoQueryDto
            {
                Id = x.Producto.Id,
                Nombre = x.Producto.Nombre,
                Precio = x.Producto.Precio
            },
            Cantidad = x.Cantidad
        }).ToList();
    }

    public void UpdateItemCarritos(Guid iditemcarrito, ItemCarritoCommandDto itemCarritoDto, Guid IdProducto)
    {
        var itemCarrito = context.ItemCarritos.FirstOrDefault(x => x.IdItemCarrito == iditemcarrito);

        var producto = context.Productos.FirstOrDefault(x => x.Id == IdProducto);

        if (itemCarrito != null)
        {
            itemCarrito.Producto = producto;
            itemCarrito.Cantidad = itemCarrito.Cantidad;
            context.SaveChanges();
        }
    }
}