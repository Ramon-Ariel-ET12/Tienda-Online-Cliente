using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacion.Dominio;
[Table("Cliente")]
public class Cliente
{
    [Key]
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    [StringLength(50)]
    public string Nombre { get; set; }
    [Required]
    [StringLength(50)]
    public string Apellido { get; set; }
    [Required]
    [StringLength(60)]
    public string Email { get; set; }
    [Required]
    [StringLength(50)]
    public string Usuario { get; set; }
    [Required]
    public string Contraseña { get; set; }
    public Cliente(string nombre, string apellido, string email, string usuario, string contraseña)
    {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Usuario = usuario;
        Contraseña = contraseña;
    }
}