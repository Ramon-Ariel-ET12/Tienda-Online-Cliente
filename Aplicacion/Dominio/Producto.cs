using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacion.Dominio;
[Table("Producto")]
public class Producto
{
    [Key]
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    [StringLength(50)]
    public string Nombre { get; set; } = string.Empty;
    [Required]
    [StringLength(100)]
    public string Descripcion { get; set; } = string.Empty;
    [Required]
    [StringLength(50)]
    public Categoria? Categoria { get; set; }
    [Required]
    public int Cantidad { get; set; }
    [Required]
    public int Precio { get; set; }

    public Producto(string nombre, string descripcion, int cantidad, int precio)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        Cantidad = cantidad;
        Precio = precio;
    }
}