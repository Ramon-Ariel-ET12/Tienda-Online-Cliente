using Aplicacion.Dominio;
namespace Api.Funcionalidades.Clientes;

public interface IClienteService
{
    List<Cliente> GetClientes();
}

public class ClienteService : IClienteService
{
    List<Cliente> clientes;
    public ClienteService()
    {
        clientes = new List<Cliente>()
        {
            new Cliente("Ramón", "Lugones", "correoderamon@gmail.com", "Ramon-Ariel-ET12", "Messi"),
            new Cliente("Josbert", "Rizzo", "correodejosbert@gmail.com", "JJRR", "tito")
        };
    }

    public List<Cliente> GetClientes()
    {
        return clientes;
    }
}