
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
    public List<Producto>? productos { get; set; }
    [Required]
    [StringLength(100)]
    public string Descripcion { get; set; } = string.Empty;
    public Categoria(string nombre, string descripcion)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        productos = new List<Producto>();
    }
    public void AgregarProductos(Producto producto)=>productos?.Add(producto);
}