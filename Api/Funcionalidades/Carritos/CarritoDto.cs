using Api.Funcionalidades.ItemCarritos;
using Api.Funcionalidades.Productos;

namespace Api.Funcionalidades.Carritos;
public class CarritoCommandDto
{
    public Guid IdCliente { get; set; } = Guid.NewGuid();
    public required double Total { get; set; }
}
public class CarritoQueryDto
{
    public Guid Id { get; set; } 
    public Guid IdCliente { get; set; }
    public double Total { get; set; }
    public List<ItemCarritoQueryDto> Productos { get; set; } = new List<ItemCarritoQueryDto>();
}