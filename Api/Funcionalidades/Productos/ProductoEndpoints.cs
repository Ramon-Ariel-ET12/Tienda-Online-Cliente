using Carter;
using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.Productos;
public class ProductoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/producto", ([FromServices] IProductoService productoService) =>
        {
            return Results.Ok(productoService.GetProductos());
        });
    }
}