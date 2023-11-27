using Carter;
using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.Carritos;
public class CarritoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        #region 

        app.MapGet("/api/Carrito",([FromServices]ICarritoService carritoService)=>
        {
            return Results.Ok(carritoService.GetCarrito());
        });
        
        app.MapPost("/api/Carrito",([FromServices]ICarritoService carritoService,CarritoCommandDto carritoDto)=>
        {
            carritoService.CreateCarrito(carritoDto);
            return Results.Ok();
        });
        app.MapPut("/api/Carrito/{Idcarrito}",([FromServices]ICarritoService carritoService,CarritoCommandDto carritoDto,Guid Idcarrito)=>
        {
            carritoService.UpdateCarrito(Idcarrito,carritoDto);
            return Results.Ok();
        });
        app.MapDelete("/api/Carrito/{Idcarrito}",([FromServices]ICarritoService carritoService,Guid Idcarrito)=>
        {
            carritoService.DeleteCarrito(Idcarrito);
            return Results.Ok();
        });
        #endregion
        #region ListItem
        app.MapPost("/api/Carrito/{Idcarrito}/itemcarrito/{Iditemcarrito}",([FromServices]ICarritoService carritoService,Guid Idcarrito,Guid Iditemcarrito)=>
        {
            carritoService.AddItemcarrito(Idcarrito,Iditemcarrito);
            return Results.Ok();
        });
        app.MapDelete("/api/Carrito/{Idcarrito}/itemcarrito/{Iditemcarrito}/Delete",([FromServices]ICarritoService carritoService,Guid Idcarrito,Guid Iditemcarrito)=>
        {
            carritoService.DeleteItemCarrito(Idcarrito,Iditemcarrito);
            return Results.Ok();
        });
        #endregion
    }
}