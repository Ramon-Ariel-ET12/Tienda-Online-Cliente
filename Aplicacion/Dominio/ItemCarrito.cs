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
    public int Cantidad { get; set; }
    [Required]
    public double Subtotal { get; set; }

    public ItemCarrito()
    {
    }
    public ItemCarrito(Producto producto, Carrito carrito)
    {
        Producto = producto;
        Carrito = carrito;
        Cantidad = 0;
        Subtotal = 0;
    }
}