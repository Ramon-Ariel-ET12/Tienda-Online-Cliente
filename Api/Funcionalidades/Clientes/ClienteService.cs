using Aplicacion.Dominio;
using Api.Persistencia;

namespace Api.Funcionalidades.Clientes;

public interface IClienteService
{
    void DeleteCliente(Guid Idcliente);
    void UpdateCliente(Guid Idcliente, ClienteDto clienteDto);
    void CreateCliente(ClienteDto clienteDto);
    List<Cliente> GetClientes();
}

public class ClienteService : IClienteService
{
    private readonly TiendaOnlineDbContext context;
    public ClienteService(TiendaOnlineDbContext context)
    {
        this.context = context;
    }

    public void CreateCliente(ClienteDto clienteDto)
    {
        context.Clientes.Add(new Cliente(clienteDto.Nombre, clienteDto.Apellido, clienteDto.Email, clienteDto.Usuario, clienteDto.Contraseña));

        context.SaveChanges();
    }

    public void DeleteCliente(Guid Idcliente)
    {
        var cliente = context.Clientes.FirstOrDefault(x => x.Id == Idcliente);

        if (cliente != null)
        {
            context.Remove(cliente);

            context.SaveChanges();
        }
    }

    public List<Cliente> GetClientes()
    {
        return context.Clientes.ToList();
    }

    public void UpdateCliente(Guid Idcliente, ClienteDto clienteDto)
    {
        var cliente = context.Clientes.FirstOrDefault(x => x.Id == Idcliente);

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