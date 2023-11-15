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
    }
}