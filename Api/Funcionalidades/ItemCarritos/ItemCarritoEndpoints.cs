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

        app.MapPost("/api/itemCarrito", ([FromServices] IItemCarritoService itemCarritoService, ItemCarritoCommandDto itemCarritoDto, Guid Idproducto, Guid Idcarrito) =>
        {
            itemCarritoService.CreateItemCarritos(itemCarritoDto, Idproducto, Idcarrito);
            return Results.Ok();
        });
        app.MapPut("/api/itemCarrito/{Iditemcarrito}", ([FromServices] IItemCarritoService itemCarritoService, ItemCarritoCommandDto ItemCarrito, Guid Iditemcarrito, Guid Idproducto, Guid Idcarrito) =>
        {
            itemCarritoService.UpdateItemCarritos(ItemCarrito, Iditemcarrito, Idproducto, Idcarrito);
            return Results.Ok();
        });
        app.MapDelete("/api/itemCarrito/{Iditemcarrito}/carrito/{Idcarrito}/Delete", ([FromServices] IItemCarritoService itemCarritoService, Guid Iditemcarrito, Guid Idcarrito) =>
        {
            itemCarritoService.DeleteItemCarritos(Iditemcarrito, Idcarrito);
            return Results.Ok();
        });

    }

}