using Aplicacion.Dominio;

namespace Api.Funcionalidades.Productos;
public class ProductoCommandDto
{
    public required string Nombre { get; set; }
    public required double Precio { get; set; }
    public required int Stock { get; set; }
}
public class ProductoQueryDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public double Precio { get; set; }
    public int Stock { get; set; }
}