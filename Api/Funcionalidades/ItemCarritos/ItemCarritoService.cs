namespace Api.Funcionalidades.ItemCarritos;

using System;
using Api.Persistencia;
using Aplicacion.Dominio;
public interface IItemCarritoService
{
    void CreateItemCarritos(ItemCarritoCommandDto itemCarrito, Guid Idproducto, Guid Idcarrito);
    void DeleteItemCarritos(Guid Iditemcarrito);
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
            if (itemCarrito.Unidades > 0){
                if (itemCarrito.Unidades < producto.Stock)
                {
                    carrito.Total = carrito.Total + producto.Precio * itemCarrito.Unidades ;
                    carrito.Cantidad = carrito.Cantidad + itemCarrito.Unidades;
                    context.ItemCarritos.Add(new ItemCarrito(producto, carrito, itemCarrito.Unidades));
                    context.SaveChanges();
                } else { 
                    throw new Exception("Se a pasado el limite de stock");
                }
            } else { 
                throw new Exception("Elija la cantidad de producto adecuadamente");
            }
    }

public void DeleteItemCarritos(Guid Iditemcarrito)
{
    var itemCarrito = context.ItemCarritos.FirstOrDefault(x => x.IdItemCarrito == Iditemcarrito);
    var carrito = context.Carritos.FirstOrDefault(x => x.Id == itemCarrito.Carrito.Id);
    if (itemCarrito != null)
    {
        carrito.Total = carrito.Total - itemCarrito.Subtotal;
        carrito.Cantidad = carrito.Cantidad - itemCarrito.Unidades;        

        context.Remove(itemCarrito);
        context.SaveChanges();
    }
}

    public List<ItemCarritoQueryDto> GetItemCarritos()
    {
        return context.ItemCarritos.Select(x => new ItemCarritoQueryDto { 
            Carrito = x.Carrito.Id,
            IdItemCarrito = x.IdItemCarrito,
            Producto = new Productos.ProductoQueryDto2 { 
                Id = x.Producto.Id, 
                Nombre = x.Producto.Nombre, 
                Precio = x.Producto.Precio 
            },
            Unidades = x.Unidades,
            Subtotal = x.Subtotal
            }).ToList();
    }

    public void UpdateItemCarritos(ItemCarritoCommandDto ItemCarrito, Guid Iditemcarrito, Guid Idproducto, Guid Idcarrito)
    {
        var item = context.ItemCarritos.FirstOrDefault(x=>x.IdItemCarrito == Iditemcarrito);
        
        var producto = context.Productos.FirstOrDefault(x => x.Id == Idproducto);

        var carrito = context.Carritos.FirstOrDefault(x => x.Id == Idcarrito);
        if (item!=null)
        {
            item.Producto = producto;
            item.Unidades = ItemCarrito.Unidades;
            item.Subtotal = ItemCarrito.Unidades * item.Producto.Precio;
            
            context.SaveChanges();
        }
    }
}