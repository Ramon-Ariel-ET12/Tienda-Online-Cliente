using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacion.Dominio;
[Table("Cliente")]
public class Cliente
{
    [Key]
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<Carrito>? carritos { get; set; }   
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
    public Cliente(List<Carrito>? carritos)
    {
        
    }
    public Cliente(string nombre, string apellido, string email, string usuario, string contraseña)
    {
        Validacion.ValidacionCadena(nombre, "error Nombre");
        Nombre = nombre;
        Validacion.ValidacionCadena(apellido, "error Apellido");
        Apellido = apellido;
        Validacion.ValidarEmail(email, "error Email");
        Email = email;
        Validacion.ValidacionCadena(usuario, "error Usuario");
        Usuario = usuario;
        Validacion.ValidacionCadena(contraseña, "error contraseña");
        Contraseña = contraseña;
        carritos = new List<Carrito>();
    }
    public void AgregarCarrito(Carrito carrito)=>carritos?.Add(carrito); 
}