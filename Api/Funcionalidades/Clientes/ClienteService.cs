using Aplicacion.Dominio;
using Api.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Api.Funcionalidades.Clientes;

public interface IClienteService
{
    void CreateClientes(ClienteCommandDto clienteDto);
    void DeleteClientes(Guid clienteid);
    List<ClienteQueryDto> GetClientes();
    void UpdateClientes(Guid clienteid, ClienteCommandDto clienteDto);
}
public class ClienteService : IClienteService
{
    private readonly TiendaOnlineDbContext context;
    public ClienteService(TiendaOnlineDbContext context)
    {
        this.context = context;
    }

    public void CreateClientes(ClienteCommandDto clienteDto)
    {
        context.Clientes.Add(new Cliente(clienteDto.Nombre, clienteDto.Apellido,
        clienteDto.Email, clienteDto.Usuario, clienteDto.Contraseña));
        context.SaveChanges();
    }

    public void DeleteClientes(Guid clienteid)
    {
        var cliente = context.Clientes.FirstOrDefault(x => x.Id == clienteid);
        if (cliente != null)
        {
            context.Remove(cliente);
            context.SaveChanges();
        }
    }

    public List<ClienteQueryDto> GetClientes()
    {
        return context.Clientes
        .Select(x => new ClienteQueryDto
        {
            Id = x.Id,
            Nombre = x.Nombre,
            Apellido = x.Apellido,
            Email = x.Email,
            Usuario = x.Usuario,
            Contraseña = x.Contraseña,
        }).ToList();
    }

    public void UpdateClientes(Guid clienteid, ClienteCommandDto clienteDto)
    {
        var cliente = context.Clientes.FirstOrDefault(x => x.Id == clienteid);
        if (cliente != null)
        {
            cliente.Nombre = clienteDto.Nombre;
            cliente.Apellido = clienteDto.Apellido;
            cliente.Email = clienteDto.Email;
            cliente.Usuario = clienteDto.Usuario;
            cliente.Contraseña = clienteDto.Contraseña;
            context.SaveChanges();
        }
    }
}