namespace Api.Funcionalidades.Clientes;
public class ClienteDto
{
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Email { get; set; }
    public required string Usuario { get; set; }
    public required string Contraseña { get; set; }
}