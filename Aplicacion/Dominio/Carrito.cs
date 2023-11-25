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
    public int Cantidad { get; set; }
    [Required]
    public double Total { get; set; }
    public Carrito(int cantidad, double total)
    {
        Cantidad = cantidad;
        Total = total;
    }
}