using Api.Funcionalidades.ItemCarritos;
using Api.Funcionalidades.Productos;
using Aplicacion.Dominio;

namespace Api.Funcionalidades.Carritos;
public class CarritoCommandDto
{
}
public class CarritoQueryDto
{
    public Guid Id { get; set; } 
    public Guid Cliente { get; set; }
    public List<ItemCarritoQueryDto2>? Productos { get; set; }
    public int? Cantidad { get; set; }
    public double? Total { get; set; }
}