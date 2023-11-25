namespace Api.Funcionalidades.Clientes;
public class ClienteCommandDto
{

    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Email { get; set; }
    public required string Usuario { get; set; }
    public required string Contraseña { get; set; }
}
public class ClienteQueryDto
{
    public Guid Id { get; set; } 
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Usuario { get; set; } = string.Empty;
    public string Contraseña { get; set; } = string.Empty;
}