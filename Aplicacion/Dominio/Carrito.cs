using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacion.Dominio;
[Table("Carrito")]
public class Carrito
{
    [Key]
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();
    public Cliente? Cliente { get; set; }
    public List<ItemCarrito> productos { get; set; }

    public int Cantidad { get; set; }
    public double Total { get; set; }
    public Carrito(Cliente? cliente)
    {
        Cliente = cliente;
        Cantidad = productos.Count();
        Total = productos.Sum(x => x.Subtotal);
        productos = new List<ItemCarrito>();
    }

    public Carrito()
    {
    }

    public void AgregarProductos(ItemCarrito itemCarrito)=>productos?.Add(itemCarrito);

}