namespace Api.Funcionalidades.ItemCarritos;

using System;
using Api.Persistencia;
using Aplicacion.Dominio;
public interface IItemCarritoService
{
    void CreateItemCarritos(ItemCarritoCommandDto itemCarrito, Guid Idproducto, Guid Idcarrito);
    void DeleteItemCarritos(Guid Iditemcarrito, Guid Idcarrito);
    List<ItemCarritoQueryDto>GetItemCarritos();
    void UpdateItemCarritos(ItemCarritoCommandDto ItemCarrito, Guid Iditemcarrito, Guid Idproducto, Guid Idcarrito);
}
public  class ItemCarritoService : IItemCarritoService
{
    private readonly TiendaOnlineDbContext context;
    public ItemCarritoService(TiendaOnlineDbContext context)
    {

        this.context = context;

    }

    public void CreateItemCarritos(ItemCarritoCommandDto itemCarrito, Guid Idproducto, Guid Idcarrito)
    {
        var producto = context.Productos.FirstOrDefault(x => x.Id == Idproducto);
        var carrito = context.Carritos.FirstOrDefault(x => x.Id == Idcarrito);
        producto.Stock = producto.Stock - itemCarrito.Cantidad;
        carrito.Total = carrito.Total + producto.Precio * itemCarrito.Cantidad ;
        carrito.Cantidad = carrito.Cantidad + itemCarrito.Cantidad;
        context.ItemCarritos.Add(new ItemCarrito(producto, carrito, itemCarrito.Cantidad));
        context.SaveChanges();
    }

public void DeleteItemCarritos(Guid Iditemcarrito, Guid Idcarrito)
{
    var itemCarrito = context.ItemCarritos.FirstOrDefault(x => x.IdItemCarrito == Iditemcarrito);
    var carrito = context.Carritos.FirstOrDefault(x => x.Id == Idcarrito);
    if (itemCarrito != null && carrito != null)
    {
        carrito.Total = carrito.Total - itemCarrito.Subtotal;
        carrito.Cantidad = carrito.Cantidad - 1;
        

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
            }, Cantidad = x.Cantidad
            , Carrito = x.Carrito.Id }).ToList();
    }

    public void UpdateItemCarritos(ItemCarritoCommandDto ItemCarrito, Guid Iditemcarrito, Guid Idproducto, Guid Idcarrito)
    {
        var item = context.ItemCarritos.FirstOrDefault(x=>x.IdItemCarrito == Iditemcarrito);
        
        var producto = context.Productos.FirstOrDefault(x => x.Id == Idproducto);

        var carrito = context.Carritos.FirstOrDefault(x => x.Id == Idcarrito);
        if (item!=null)
        {
            item.Producto = producto;
            item.Cantidad = ItemCarrito.Cantidad;
            context.SaveChanges();
        }
    }
}