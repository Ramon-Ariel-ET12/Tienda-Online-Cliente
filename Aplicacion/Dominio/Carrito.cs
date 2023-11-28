using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacion.Dominio;
[Table("Carrito")]
public class Carrito
{
    [Key]
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<ItemCarrito> productos { get; set; }

    public int Cantidad { get; set; }
    public double Total { get; set; }
    public Carrito(Guid id, int cantidad, double total)
    {
        Id = id;
        Cantidad = cantidad;
        Total = total;
        productos = new List<ItemCarrito>();
    }
    public void AgregarProductos(ItemCarrito itemCarrito)=>productos?.Add(itemCarrito);

}