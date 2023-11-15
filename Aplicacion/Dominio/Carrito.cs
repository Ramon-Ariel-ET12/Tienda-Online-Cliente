using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacion.Dominio;
[Table("Carrito")]
public class Carrito
{
    [Key]
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    public Cliente Cliente { get; set; }
    [Required]
    public List<Producto> Productos { get; set; }
    [Required]
    public int Cantidad { get; set; }
    [Required]
    public double Total { get; set; }
    public Carrito(Cliente cliente, List<Producto> productos, int cantidad, double total)
    {
        Cliente = cliente;
        Cantidad = cantidad;
        Productos = productos;
        Total = total;
    }
}