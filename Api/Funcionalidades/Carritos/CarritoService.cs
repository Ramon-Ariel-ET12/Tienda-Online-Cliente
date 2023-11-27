using Api.Funcionalidades.Clientes;
using Api.Funcionalidades.Productos;
using Aplicacion.Dominio;
using Api.Persistencia;
using Api.Funcionalidades.ItemCarritos;
using Microsoft.EntityFrameworkCore;

namespace Api.Funcionalidades.Carritos;

public interface ICarritoService
{
    void AddItemcarrito(Guid carritoid, Guid itemcarritoid);
    void CreateCarrito(CarritoCommandDto carritoDto);
    void DeleteCarrito(Guid carritoid);
    void DeleteItemCarrito(Guid carritoid, Guid itemcarritoid);
    List<CarritoQueryDto> GetCarrito();
    void UpdateCarrito(Guid carritoid, CarritoCommandDto carritoDto);
}
public class CarritoService : ICarritoService
{
    private readonly TiendaOnlineDbContext context;
    public CarritoService(TiendaOnlineDbContext context)
    {
        this.context = context;
    }

    public void AddItemcarrito(Guid carritoid, Guid itemcarritoid)
    {
        var carrito = context.Carritos.Where(x => x.Id == carritoid).Include(x => x.Productos).First();
        var itemCarrito = context.ItemCarritos.Where(x => x.IdItemCarrito == itemcarritoid).Include(x => x.Producto).First();
        if (carrito != null && itemCarrito != null)
        {
            carrito.AgregarProductos(itemCarrito);
            context.SaveChanges();
        }
    }

    public void CreateCarrito(CarritoCommandDto carritoDto)
    {
        context.Carritos.Add(new Carrito(carritoDto.IdCliente, carritoDto.Total));
        context.SaveChanges();
    }

    public void DeleteCarrito(Guid carritoid)
    {
        var carrito = context.Carritos.FirstOrDefault(x => x.Id == carritoid);
        if (carrito != null)
        {
            context.Remove(carrito);
            context.SaveChanges();
        }
    }

    public void DeleteItemCarrito(Guid carritoid, Guid itemcarritoid)
    {
        var carrito = context.Carritos.Where(x => x.Id == carritoid).Include(x=>x.Productos).First();
        var itemCarrito = carrito.Productos.FirstOrDefault(x => x.IdItemCarrito == itemcarritoid);
        if (carrito != null && itemCarrito != null)
        {
            carrito.Productos.Remove(itemCarrito);
            context.SaveChanges();
        }
    }

    public List<CarritoQueryDto> GetCarrito()
    {
        var carrito = context.Carritos.Include(x => x.Productos).ThenInclude(x => x.Producto)
        .Select( x=>new CarritoQueryDto
        {
            Id=x.Id,
            IdCliente=x.IdCliente,
            Total=x.Total,
            Productos = x.Productos.Select(y => new ItemCarritoQueryDto { IdItemCarrito=y.IdItemCarrito,Cantidad = y.Cantidad, Producto = new ProductoQueryDto { Id = y.Producto.Id, Nombre = y.Producto.Nombre} }).ToList()
        }).ToList();

        return carrito;
    }

    public void UpdateCarrito(Guid carritoid, CarritoCommandDto carritoDto)
    {
        var carrito = context.Carritos.FirstOrDefault(x => x.Id == carritoid);
        if (carrito != null)
        {
            carrito.IdCliente = carritoDto.IdCliente;
        }
    }
}