using Carter;
using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.Clientes;
public class ClienteEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/Cliente", ([FromServices] IClienteService clienteService) =>
        {
            return Results.Ok(clienteService.GetClientes());
        });

        app.MapPost("/api/Cliente", ([FromServices] IClienteService clienteService, ClienteDto clienteDto) => {
            clienteService.CreateCliente(clienteDto);
            
            return Results.Ok();
        });

        app.MapPut("/api/Cliente{Idcliente}", ([FromServices] IClienteService clienteService, Guid Idcliente, ClienteDto clienteDto) => {
            clienteService.UpdateCliente(Idcliente, clienteDto);

            return Results.Ok();
        });

            app.MapDelete("/api/Cliente{Idcliente}", ([FromServices] IClienteService clienteService, Guid Idcliente) => {
            clienteService.DeleteCliente(Idcliente);

            return Results.Ok();
        });
    }
}