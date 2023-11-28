using Api.Funcionalidades.Productos;
using Carter;
using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.ItemCarritos;
public class ItemCarritoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/itemCarrito", ([FromServices] IItemCarritoService itemCarritoService) =>
        {
            return Results.Ok(itemCarritoService.GetItemCarritos());
        });

        app.MapPost("/api/itemCarrito", ([FromServices] IItemCarritoService itemCarritoService, ItemCarritoCommandDto2 itemCarritoDto, Guid idcarrito) =>
        {
            itemCarritoService.CreateItemCarritos(itemCarritoDto, idcarrito);
            return Results.Ok();
        });
        app.MapPut("/api/itemCarrito/{Iditemcarrito}", ([FromServices] IItemCarritoService itemCarritoService, ItemCarritoCommandDto itemCarritoDto, Guid Iditemcarrito, Guid IdProducto) =>
        {
            itemCarritoService.UpdateItemCarritos(Iditemcarrito, itemCarritoDto, IdProducto);
            return Results.Ok();
        });
        app.MapDelete("/api/itemCarrito/{Iditemcarrito}", ([FromServices] IItemCarritoService itemCarritoService, Guid Iditemcarrito) =>
        {
            itemCarritoService.DeleteItemCarritos(Iditemcarrito);
            return Results.Ok();
        });
    }
}