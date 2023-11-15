using Api.Funcionalidades.Clientes;
using Api.Funcionalidades.Productos;
using Aplicacion.Dominio;

namespace Api.Funcionalidades.Carritos;

public interface ICarritoService
{
    List<Carrito> GetCarritos();
    List<Carrito> PutCarritos();
}
public class CarritoService : ICarritoService
{
    List<Carrito> carritos;
    public CarritoService(IProductoService productoService, IClienteService clienteService)
    {
        List<Producto> productos = productoService.GetProductos();
        List<Cliente> clientes = clienteService.GetClientes();
        int total = productos.Sum(x => x.Precio);
        List<string> nombresProductos = productos.Select(p => p.Nombre).ToList();
        carritos = new List<Carrito>()
        {
            new Carrito(clientes[0], productos, 2, total)
        };
    }
    public List<Carrito> GetCarritos()
    {
        return carritos;
    }

    public List<Carrito> PutCarritos()
    {
        throw new NotImplementedException();
    }
}