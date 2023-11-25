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
        app.MapPost("/api/producto", ([FromServices] IProductoService productoService, ProductoCommandDto productoDto) =>
    {
        productoService.Createproducto(productoDto);
        return Results.Ok();
    });
        app.MapPut("/api/producto/{productoId}", ([FromServices] IProductoService productoService, Guid productoid, ProductoCommandDto productoDto) =>
    {
        productoService.Updateproducto(productoid, productoDto);
        return Results.Ok();
    });
        app.MapDelete("/api/producto/{productoId}", ([FromServices] IProductoService productoService, Guid productoid) =>
    {
        productoService.Daleteproducto(productoid);
        return Results.Ok();
    });

    }
}