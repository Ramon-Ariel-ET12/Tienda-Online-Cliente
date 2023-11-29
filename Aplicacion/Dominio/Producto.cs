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
    public string Nombre { get; set; } = string.Empty;
    [Required]
    public double Precio { get; set; }
    [Required]
    [StringLength(50)]
    public string Descripcion { get; set; } = string.Empty;
    
    [ForeignKey("IdCategoria")]
    public Categoria? categorias { get; set; }
    [Required]
    public int Stock { get; set; }
    public Producto()
    {
    }

    public Producto(Categoria categoria,string Nombre, double Precio, string Descripcion, int Stock)
    {
        categorias = categoria;
        Validacion.ValidacionCadena(Nombre, "error Nombre");
        this.Nombre = Nombre;
        Validacion.ValidacionValor(Precio, "error precio");
        this.Precio = Precio;
        Validacion.ValidacionCadena(Nombre, "error Nombre");
        this.Descripcion = Descripcion;
        this.Stock = Stock;
    }
}