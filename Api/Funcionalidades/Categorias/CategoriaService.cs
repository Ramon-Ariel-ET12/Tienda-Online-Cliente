using Aplicacion.Dominio;
using Api.Persistencia;
using Microsoft.EntityFrameworkCore;
using Api.Funcionalidades.Productos;
namespace Api.Funcionalidades.Categorias;

public interface ICategoriaService
{
    void CreateCategoria(CategoriaCommandDto categoriaDto);
    void DeleteCategoria(Guid Idcategoria);
    List<CategoriaQueryDto> GetCategoria();
    void UpdateCategoria(Guid Idcategoria, CategoriaCommandDto categoriaDto);
}
public class CategoriaService : ICategoriaService
{
    private readonly TiendaOnlineDbContext context;
    public CategoriaService(TiendaOnlineDbContext context)
    {
        this.context = context;
    }

    public void CreateCategoria(CategoriaCommandDto categoriaDto)
    {
        context.Categorias.Add(new Categoria(categoriaDto.Nombre, categoriaDto.Descripcion));
        context.SaveChanges();
    }

    public void DeleteCategoria(Guid Idcategoria)
    {
        var categoria = context.Categorias.FirstOrDefault(x => x.Id == Idcategoria);
        if (categoria != null)
        {
            context.Remove(categoria);
            context.SaveChanges();
        }
    }

    public List<CategoriaQueryDto> GetCategoria()
    {
        var categoria = context.Categorias.Include(x => x.productos)
        .Select(x => new CategoriaQueryDto
        {
            Id = x.Id,
            Nombre = x.Nombre,
            Descripcion = x.Descripcion,
            Productos = x.productos.Select(y => new ProductoQueryDto2 { Id = y.Id, Nombre = y.Nombre, Precio = y.Precio}).ToList()
        }).ToList();

        return categoria;
    }
    public void UpdateCategoria(Guid Idcategoria, CategoriaCommandDto categoriaDto)
    {
        var categoria = context.Categorias.FirstOrDefault(x => x.Id == Idcategoria);
        if (categoria != null)
        {
            categoria.Nombre = categoriaDto.Nombre;
            categoria.Descripcion = categoriaDto.Descripcion;
            context.SaveChanges();
        }
    }
}