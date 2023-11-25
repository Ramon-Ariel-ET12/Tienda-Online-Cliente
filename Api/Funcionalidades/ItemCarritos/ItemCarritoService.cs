using Api.Persistencia;
using Aplicacion.Dominio;

namespace Api.Funcionalidades.ItemCarritos;

public interface IItemCarritoService
{
    void CreateItemCarritos(ItemCarritoCommandDto itemCarrito);
    void DeleteItemCarritos(Guid itemcarritoid);
    List<ItemCarritoQueryDto>GetItemCarritos();
    void UpdateItemCarritos(Guid itemcarritoid, ItemCarritoCommandDto itemCarrito);
}
public  class ItemCarritoService : IItemCarritoService
{
    private readonly TiendaOnlineDbContext context;
    public ItemCarritoService(TiendaOnlineDbContext context)
    {

        this.context = context;

    }

    public void CreateItemCarritos(ItemCarritoCommandDto itemCarrito)
    {
        var producto = context.Productos.FirstOrDefault(x => x.Id == itemCarrito.IdProducto);
        context.ItemCarritos.Add(new ItemCarrito(producto,itemCarrito.Cantidad));
        context.SaveChanges();
    }

    public void DeleteItemCarritos(Guid itemcarritoid)
    {
        var itemCarrito=context.ItemCarritos.FirstOrDefault(x=>x.IdItemCarrito == itemcarritoid);
        if(itemCarrito!=null)
        {
            context.Remove(itemCarrito);
            context.SaveChanges();
        }
    }

    public List<ItemCarritoQueryDto> GetItemCarritos()
    {
        return context.ItemCarritos.Select(x => new ItemCarritoQueryDto { 
            IdItemCarrito = x.IdItemCarrito,
            Producto = new Productos.ProductoQueryDto { 
                Id = x.Producto.Id, 
                Nombre = x.Producto.Nombre, 
                Precio = x.Producto.Precio 
            }, Cantidad = x.Cantidad }).ToList();
    }

    public void UpdateItemCarritos(Guid itemcarritoid, ItemCarritoCommandDto itemCarritoDto)
    {
        var itemCarrito = context.ItemCarritos.FirstOrDefault(x=>x.IdItemCarrito == itemcarritoid);
        
        var producto = context.Productos.FirstOrDefault(x => x.Id == itemCarritoDto.IdProducto);

        if (itemCarrito!=null)
        {
            itemCarrito.Producto = producto;
            itemCarrito.Cantidad = itemCarrito.Cantidad;
            context.SaveChanges();
        }
    }
}