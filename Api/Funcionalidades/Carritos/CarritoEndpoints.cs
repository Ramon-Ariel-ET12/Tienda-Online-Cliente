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
        
        app.MapPost("/api/Carrito",([FromServices]ICarritoService carritoService,CarritoCommandDto carritoDto, Guid Idcliente)=>
        {
            carritoService.CreateCarrito(carritoDto, Idcliente);
            return Results.Ok();
        });
        app.MapPut("/api/Carrito/{Idcarrito}",([FromServices]ICarritoService carritoService,Guid Idcliente,Guid Idcarrito)=>
        {
            carritoService.UpdateCarrito(Idcarrito, Idcliente);
            return Results.Ok();
        });
        app.MapDelete("/api/Carrito/{Idcarrito}/Delete",([FromServices]ICarritoService carritoService,Guid Idcarrito)=>
        {
            carritoService.DeleteCarrito(Idcarrito);
            return Results.Ok();
        });
        app.MapDelete("/api/Carrito/{Idcarrito}/Buy",([FromServices]ICarritoService carritoService,Guid Idcarrito)=>
        {
            carritoService.BuyCarrito(Idcarrito);
            return Results.Ok();
        });
        #endregion
    }
}