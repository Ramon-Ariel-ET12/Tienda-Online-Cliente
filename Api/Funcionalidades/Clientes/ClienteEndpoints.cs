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
        app.MapPut("/api/Cliente/{Idcliente}", ([FromServices] IClienteService clienteService, Guid Idcliente, ClienteCommandDto clienteDto) =>
        {
            clienteService.UpdateClientes(Idcliente, clienteDto);
            return Results.Ok();
        });
        app.MapDelete("/api/Cliente/{Idcliente}", ([FromServices] IClienteService clienteService, Guid Idcliente) =>
        {
            clienteService.DeleteClientes(Idcliente);
            return Results.Ok();
        });
        #endregion
    }
}