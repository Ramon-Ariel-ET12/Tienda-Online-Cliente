using Api.Funcionalidades.Clientes;
using Api.Funcionalidades.Productos;
using Aplicacion.Dominio;
using Api.Persistencia;
using Api.Funcionalidades.ItemCarritos;
using Microsoft.EntityFrameworkCore;

namespace Api.Funcionalidades.Carritos;

public interface ICarritoService
{
    void AddItemcarrito(Guid Idcarrito, Guid itemIdcarrito);
    void CreateCarrito(CarritoCommandDto carritoDto, Guid Idcliente);
    void DeleteCarrito(Guid Idcarrito);
    void DeleteItemCarrito(Guid Idcarrito, Guid itemIdcarrito);
    List<CarritoQueryDto> GetCarrito();
    void UpdateCarrito(Guid Idcarrito, Guid Idcliente);
}
public class CarritoService : ICarritoService
{
    private readonly TiendaOnlineDbContext context;
    public CarritoService(TiendaOnlineDbContext context)
    {
        this.context = context;
    }

    public void AddItemcarrito(Guid Idcarrito, Guid itemIdcarrito)
    {
        var carrito = context.Carritos.Where(x => x.Id == Idcarrito).Include(x => x.productos).First();
        var itemCarrito = context.ItemCarritos.Where(x => x.IdItemCarrito == itemIdcarrito).Include(x => x.Producto).First();
        if (carrito != null && itemCarrito != null)
        {
            carrito.AgregarProductos(itemCarrito);
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

    public void DeleteItemCarrito(Guid Idcarrito, Guid itemIdcarrito)
    {
        var carrito = context.Carritos.Where(x => x.Id == Idcarrito).Include(x=>x.productos).First();
        var itemCarrito = carrito.productos.FirstOrDefault(x => x.IdItemCarrito == itemIdcarrito);
        if (carrito != null && itemCarrito != null)
        {
            carrito.productos.Remove(itemCarrito);
            context.SaveChanges();
        }
    }

    public List<CarritoQueryDto> GetCarrito()
    {
        var carrito = context.Carritos.Include(x => x.productos).ThenInclude(x => x.Producto)
        .Select( x=>new CarritoQueryDto
        {
            Id = x.Id,
            Cliente = x.Id,
            Cantidad = x.Cantidad,
            Total = x.Total,
            Productos = x.productos.Select(y => new ItemCarritoQueryDto
                {
                    IdItemCarrito = y.IdItemCarrito,
                    Unidades = y.Unidades,
                    Producto = new ProductoQueryDto
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
        var carrito = context.Carritos.FirstOrDefault(x => x.Id == Idcarrito);
        if (carrito != null)
        {
            carrito.Cliente.Id = Idcliente;
            context.SaveChanges();
        }
    }
}