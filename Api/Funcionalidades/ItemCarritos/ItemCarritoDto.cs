using Api.Funcionalidades.Productos;
using Aplicacion.Dominio;

namespace Api.Funcionalidades.ItemCarritos;
public class ItemCarritoCommandDto
{
    public Guid IdProducto { get; set; }= Guid.NewGuid();
    public int Cantidad { get; set; }
}
public class ItemCarritoQueryDto
{
    public Guid IdItemCarrito { get; set; } 
    public required ProductoQueryDto Producto { get; set; }
    public int Cantidad { get; set; }
}