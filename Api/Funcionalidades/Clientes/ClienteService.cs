using Aplicacion.Dominio;
using Api.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Api.Funcionalidades.Clientes;

public interface IClienteService
{
    void AddCarrito(Guid clienteid, Guid carritoid);
    void CreateClientes(ClienteCommandDto clienteDto);
    void Deletecarrito(Guid clienteid, Guid carritoid);
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

    public void AddCarrito(Guid clienteid, Guid carritoid)
    {
        var cliente = context.Clientes.FirstOrDefault(x => x.Id == clienteid);
        var carrito = context.Carritos.FirstOrDefault(x => x.Id == carritoid);
        if (cliente != null && carrito != null)
        {
            cliente.AgregarCarrito(carrito);
            context.SaveChanges();
        }

    }

    public void CreateClientes(ClienteCommandDto clienteDto)
    {
        context.Clientes.Add(new Cliente(clienteDto.Nombre, clienteDto.Apellido,
        clienteDto.Email, clienteDto.Usuario, clienteDto.Contraseña));
        context.SaveChanges();
    }

    public void Deletecarrito(Guid clienteid, Guid carritoid)
    {
        var cliente = context.Clientes.Where(x => x.Id == clienteid).Include(x => x.Id == carritoid).First();
        var carrito = cliente.carritos?.FirstOrDefault(x => x.Id == carritoid);
        if (cliente != null && carrito != null)
        {
            cliente.carritos?.Remove(carrito);
            context.SaveChanges();
        }
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