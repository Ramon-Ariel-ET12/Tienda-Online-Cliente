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

    public int? Cantidad { get; set; }
    public double? Total { get; set; }
    public Carrito()
    {
    }
    
    public Carrito(Cliente cliente)
    {
        Cliente = cliente;
        Cantidad = 0;
        Total = 0;
        productos = new List<ItemCarrito>();     
    }


    public void AgregarProductos(ItemCarrito itemCarrito)=>productos?.Add(itemCarrito);

}