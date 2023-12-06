using Api.Funcionalidades.Clientes;
using Api.Funcionalidades.Productos;
using Aplicacion.Dominio;
using Api.Persistencia;
using Api.Funcionalidades.ItemCarritos;
using Microsoft.EntityFrameworkCore;

namespace Api.Funcionalidades.Carritos;

public interface ICarritoService
{
    void CreateCarrito(CarritoCommandDto carritoDto, Guid Idcliente);
    void DeleteCarrito(Guid Idcarrito);
    List<CarritoQueryDto> GetCarrito();
    void UpdateCarrito(Guid Idcarrito, Guid Idcliente);
    void BuyCarrito(Guid Idcarrito);
}
public class CarritoService : ICarritoService
{
    private readonly TiendaOnlineDbContext context;
    public CarritoService(TiendaOnlineDbContext context)
    {
        this.context = context;
    }

    public void BuyCarrito(Guid Idcarrito)
    {
        var carrito = context.Carritos
        .Include(c => c.productos)
        .ThenInclude(ic => ic.Producto)
        .FirstOrDefault(c => c.Id == Idcarrito);
        
        if (carrito != null)
        {
            foreach (var itemCarrito in carrito.productos)
            {
                if (itemCarrito.Producto.Stock >= itemCarrito.Unidades)
                {
                    itemCarrito.Producto.Stock -= itemCarrito.Unidades;
                }

            }
            context.RemoveRange(carrito.productos);
            context.Remove(carrito);
            context.SaveChanges();
        }
    }

    public void CreateCarrito(CarritoCommandDto carritoDto, Guid Idcliente)
    {
        var cliente = context.Clientes.FirstOrDefault(x => x.Id == Idcliente);
        context.Carritos.Add(new Carrito(cliente));
        context.SaveChanges();
    }

    public void DeleteCarrito(Guid Idcarrito)
    {
        var carrito = context.Carritos.FirstOrDefault(x => x.Id == Idcarrito);
        if (carrito != null)
        {
            context.Remove(carrito);
            context.SaveChanges();
        }
    }

    public List<CarritoQueryDto> GetCarrito()
    {
        var carrito = context.Carritos.Include(x => x.productos).ThenInclude(x => x.Producto)
        .Select( x=>new CarritoQueryDto
        {
            Id = x.Id,
            Cliente = x.Cliente.Id,
            Cantidad = x.Cantidad,
            Total = x.Total,
            Productos = x.productos.Select(y => new ItemCarritoQueryDto2
                {
                    IdItemCarrito = y.IdItemCarrito,
                    Unidades = y.Unidades,
                    Producto = new ProductoQueryDto2
                    {
                        Id = y.Producto.Id,
                        Nombre = y.Producto.Nombre,
                        Precio = y.Producto.Precio,
                    }                    
                }).ToList()
        }).ToList();

        return carrito;
    }

    public void UpdateCarrito(Guid Idcarrito, Guid Idcliente)
    {
        // Solo cambia el cliente, el carrito se queda intacto
        var carrito = context.Carritos.FirstOrDefault(x => x.Id == Idcarrito);

        var cliente = context.Clientes.FirstOrDefault(x => x.Id == Idcliente);

        if (carrito != null)
        {
            carrito.Cliente = cliente;
            context.SaveChanges();
        }
    }
}