using Api.Funcionalidades.Carritos;
using Api.Funcionalidades.Categorias;
using Api.Funcionalidades.Clientes;
using Api.Funcionalidades.Productos;

namespace Api.Funcionalidades;
public static class ServiceManager
{
    public static IServiceCollection AddServiceManager(this IServiceCollection services)
    {
        services.AddSingleton<IClienteService, ClienteService>();
        services.AddSingleton<ICategoriaService, CategoriaService>();
        services.AddSingleton<IProductoService, ProductoService>();
        services.AddSingleton<ICarritoService, CarritoService>();

        return services;
    }
}