namespace Api.Funcionalidades.ItemCarritos;

using System;
using Api.Persistencia;
using Aplicacion.Dominio;
public interface IItemCarritoService
{
    void CreateItemCarritos(ItemCarritoCommandDto itemCarrito, Guid Idproducto, Guid Idcarrito);
    void DeleteItemCarritos(Guid itemcarritoid);
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
        context.ItemCarritos.Add(new ItemCarrito(producto, carrito, itemCarrito.Cantidad));
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
            carrito = x.Carrito.Id,
            Producto = new Productos.ProductoQueryDto { 
                Id = x.Producto.Id, 
                Nombre = x.Producto.Nombre, 
                Precio = x.Producto.Precio 
            }, Cantidad = x.Cantidad }).ToList();
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