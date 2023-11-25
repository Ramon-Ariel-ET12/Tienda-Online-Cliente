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
        app.MapPut("/api/itemCarrito/{itemcarritoid}", ([FromServices] IItemCarritoService itemCarritoService, ItemCarritoCommandDto itemCarritoDto, Guid itemcarritoid) =>
        {
            itemCarritoService.UpdateItemCarritos(itemcarritoid, itemCarritoDto);
            return Results.Ok();
        });
        app.MapDelete("/api/itemCarrito/{itemcarritoid}", ([FromServices] IItemCarritoService itemCarritoService, Guid itemcarritoid) =>
        {
            itemCarritoService.DeleteItemCarritos(itemcarritoid);
            return Results.Ok();
        });

    }

}