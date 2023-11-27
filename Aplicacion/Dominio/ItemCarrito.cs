using System.ComponentModel.DataAnnotations;

namespace Aplicacion.Dominio;
public class ItemCarrito
{
    [Key]
    [Required]
    public Guid IdItemCarrito { get; set; } = Guid.NewGuid();

    [Required]

    public Producto? Producto { get; set; }
    [Required]
    public int Cantidad { get; set; }
    [Required]
    public double Subtotal { get; set; }
    public ItemCarrito(Producto producto, int cantidad)
    {
        Producto = producto;
        Cantidad = cantidad;
        Subtotal = producto.Precio * cantidad;
    }
}