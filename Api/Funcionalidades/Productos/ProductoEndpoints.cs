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
        app.MapPost("/api/producto", ([FromServices] IProductoService productoService, ProductoCommandDto productoDto, Guid idcategoria) =>
    {
        productoService.Createproducto(productoDto, idcategoria);
        return Results.Ok();
    });
        app.MapPut("/api/producto/{Idproducto}", ([FromServices] IProductoService productoService, Guid Idproducto, ProductoCommandDto productoDto) =>
    {
        productoService.Updateproducto(Idproducto, productoDto);
        return Results.Ok();
    });
        app.MapDelete("/api/producto/{Idproducto}", ([FromServices] IProductoService productoService, Guid Idproducto) =>
    {
        productoService.Deleteproducto(Idproducto);
        return Results.Ok();
    });
    }
}