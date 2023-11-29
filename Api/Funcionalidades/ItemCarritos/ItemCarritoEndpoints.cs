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
        app.MapPut("/api/itemCarrito/{itemcarritoid}", ([FromServices] IItemCarritoService itemCarritoService, Guid Iditemcarrito, Guid Idproducto, Guid Idcarrito) =>
        {
            itemCarritoService.UpdateItemCarritos(Iditemcarrito, Idproducto, Idcarrito);
            return Results.Ok();
        });
        app.MapDelete("/api/itemCarrito/{itemcarritoid}", ([FromServices] IItemCarritoService itemCarritoService, Guid itemcarritoid) =>
        {
            itemCarritoService.DeleteItemCarritos(itemcarritoid);
            return Results.Ok();
        });

    }

}