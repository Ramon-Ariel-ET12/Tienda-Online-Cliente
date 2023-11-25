using Carter;
using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.Clientes;
public class ClienteEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        #region Cliente
        app.MapGet("/api/Cliente", ([FromServices] IClienteService clienteService) =>
        {
            return Results.Ok(clienteService.GetClientes());
        });
        app.MapPost("/api/Cliente", ([FromServices] IClienteService clienteService, ClienteCommandDto clienteDto) =>
        {
            clienteService.CreateClientes(clienteDto);
            return Results.Ok();
        });
        app.MapPut("/api/Cliente/{clienteid}", ([FromServices] IClienteService clienteService, Guid clienteid, ClienteCommandDto clienteDto) =>
        {
            clienteService.UpdateClientes(clienteid, clienteDto);
            return Results.Ok();
        });
        app.MapDelete("/api/Cliente/{clienteid}", ([FromServices] IClienteService clienteService, Guid clienteid) =>
        {
            clienteService.DeleteClientes(clienteid);
            return Results.Ok();
        });
        #endregion
        #region ListCarrito
        app.MapPost("/api/Cliente/{clienteid}/carrito/{carritoid}", ([FromServices] IClienteService clienteService, Guid clienteid, Guid carritoid) =>
        {
            clienteService.AddCarrito(clienteid, carritoid);
            return Results.Ok();
        });
        app.MapDelete("/api/Cliente/{clienteid}/carrito/{carritoid}/Delete", ([FromServices] IClienteService clienteService, Guid clienteid, Guid carritoid) =>
        {
            clienteService.Deletecarrito(clienteid, carritoid);
            return Results.Ok();
        });

        #endregion
    }
}