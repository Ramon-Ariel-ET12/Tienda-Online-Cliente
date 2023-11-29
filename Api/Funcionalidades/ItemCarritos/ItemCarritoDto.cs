using Api.Funcionalidades.Carritos;
using Api.Funcionalidades.Productos;
using Aplicacion.Dominio;

namespace Api.Funcionalidades.ItemCarritos;
public class ItemCarritoCommandDto
{
    public int Cantidad { get; set; }
}

public class ItemCarritoQueryDto
{
    public Guid IdItemCarrito { get; set; } 
    public required ProductoQueryDto Producto { get; set; }
    public required Guid carrito { get; set; }
    public Guid Carrito { get; set; }
    public int Cantidad { get; set; }
}