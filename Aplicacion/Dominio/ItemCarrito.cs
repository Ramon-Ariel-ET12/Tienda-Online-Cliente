using System.ComponentModel.DataAnnotations;

namespace Aplicacion.Dominio;
public class ItemCarrito
{
    [Key]
    [Required]
    public Guid IdItemCarrito { get; set; } = Guid.NewGuid();

    [Required]

    public Producto? Producto { get; set; }
    public Carrito? Carrito { get; set; }
    [Required]
    public int Unidades { get; set; }
    [Required]
    public double Subtotal { get; set; }

    public ItemCarrito()
    {
    }
    public ItemCarrito(Producto producto, Carrito carrito, int unidades)
    {
        Producto = producto;
        Carrito = carrito;
        Unidades = unidades;
        Subtotal = producto.Precio * unidades;
    }
}