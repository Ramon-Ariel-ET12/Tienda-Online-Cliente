using Carter;
using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.Carritos;
public class CarritoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/Carrito", ([FromServices] ICarritoService carritoService) =>
        {
            return Results.Ok(carritoService.GetCarritos());
        });

        // app.MapPost("/api/Categoria", ([FromServices] ICarritoService carritoService, CarritoDto carritoDto) => {
        //     carritoService.CreateCarrito(carritoDto);
            
        //     return Results.Ok();
        // });

        app.MapPut("/api/Carrito{Idcarrito}", ([FromServices] ICarritoService carritoService, Guid Idcarrito, CarritoDto carritoDto) => {
            carritoService.UpdateCarrito(Idcarrito, carritoDto);

            return Results.Ok();
        });

        app.MapDelete("/api/Carrito{Idcarrito}", ([FromServices] ICarritoService carritoService, Guid Idcarrito) => {
            carritoService.DeleteCategoria(Idcarrito);

            return Results.Ok();
        });
    }
}