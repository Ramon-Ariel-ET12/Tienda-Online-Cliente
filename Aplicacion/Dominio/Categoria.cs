
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacion.Dominio;
[Table("Categoria")]
public class Categoria
{
    [Key]
    [Required]
    public Guid Id { get; protected set; } = Guid.NewGuid();
    [Required]
    [StringLength(50)]
    public string Nombre { get; set; } = string.Empty;
    [Required]
    [StringLength(100)]
    public string Descripcion { get; set; } = string.Empty;
    [ForeignKey("IdProducto")]
    public List<Producto>? productos { get; set; }
    public Categoria(string nombre, string descripcion)
    {
        Nombre = nombre;
        Descripcion = descripcion;        
    }
}