using Api.Funcionalidades.Clientes;
using Api.Funcionalidades.Productos;
using Aplicacion.Dominio;
using Api.Persistencia;

namespace Api.Funcionalidades.Carritos;

public interface ICarritoService
{
    // void CreateCarrito(CarritoDto carritoDto);
    void DeleteCategoria(Guid Idcarrito);
    List<Carrito> GetCarritos();
    void UpdateCarrito(Guid Idcarrito, CarritoDto carritoDto);
}
public class CarritoService : ICarritoService
{
    private readonly TiendaOnlineDbContext context;
    public CarritoService(TiendaOnlineDbContext context)
    {
        this.context = context;
    }

    // public void CreateCarrito(CarritoDto carritoDto)
    // {
    //     context.Carritos.Add(new Carrito(carritoDto.Cantidad, carritoDto.Total));
    // }

    public void DeleteCategoria(Guid Idcarrito)
    {
        var carrito = context.Carritos.FirstOrDefault(x => x.Id == Idcarrito);
        if (carrito != null)
        {
            context.Remove(carrito);

            context.SaveChanges();
        }
    }

    public List<Carrito> GetCarritos()
    {
        return context.Carritos.ToList();
    }

    public void UpdateCarrito(Guid Idcarrito, CarritoDto carritoDto)
    {
        var carrito = context.Carritos.FirstOrDefault(x => x.Id == Idcarrito);
        if (carrito != null)
        {

            context.SaveChanges();
        }
    }
}