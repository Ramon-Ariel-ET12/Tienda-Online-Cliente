using Api.Funcionalidades.Productos;

namespace Api.Funcionalidades.Categorias;
public class CategoriaCommandDto
{
    public required string Nombre{get; set;}
    public required string Descripcion{get; set;}
    
}
public class CategoriaQueryDto
{   
    public Guid Id { get; set; } 
    public required string Nombre{get; set;}
    public required string Descripcion{get; set;}
    public List<ProductoQueryDto2> Productos { get; set; } = new List<ProductoQueryDto2>();

}