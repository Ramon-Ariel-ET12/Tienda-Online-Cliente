using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacion.Dominio;
[Table("Producto")]
public class Producto
{
    [Key]
    [Required]
    public Guid Id { get; protected set; } = Guid.NewGuid();
    [Required]
    [StringLength(30)]
    public string Nombre { get; set; }
    [Required]
    public double Precio { get; set; }
    [Required]
    [StringLength(50)]
    public string Descripcion { get; set; } = string.Empty;
    
    [ForeignKey("IdCategoria")]
    public Categoria? categoria { get; set; } = null;

    [Required]
    public int Stock { get; set; }

    public Producto(string Nombre, double Precio, int Stock)
    {
        Validacion.ValidacionValor(Precio, "error precio");
        this.Precio = Precio;
        Validacion.ValidacionCadena(Nombre, "error Nombre");
        this.Nombre = Nombre;
        this.Stock = Stock;
    }
}