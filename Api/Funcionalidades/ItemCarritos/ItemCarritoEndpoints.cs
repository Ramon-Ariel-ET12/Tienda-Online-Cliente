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

        app.MapPost("/api/itemCarrito", ([FromServices] IItemCarritoService itemCarritoService, ItemCarritoCommandDto itemCarritoDto) =>
        {
            itemCarritoService.CreateItemCarritos(itemCarritoDto);
            return Results.Ok();
        });
        app.MapPut("/api/itemCarrito/{Iditemcarrito}", ([FromServices] IItemCarritoService itemCarritoService, ItemCarritoCommandDto itemCarritoDto, Guid Iditemcarrito) =>
        {
            itemCarritoService.UpdateItemCarritos(Iditemcarrito, itemCarritoDto);
            return Results.Ok();
        });
        app.MapDelete("/api/itemCarrito/{Iditemcarrito}", ([FromServices] IItemCarritoService itemCarritoService, Guid Iditemcarrito) =>
        {
            itemCarritoService.DeleteItemCarritos(Iditemcarrito);
            return Results.Ok();
        });

    }

}