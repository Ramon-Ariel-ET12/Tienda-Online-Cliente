using Aplicacion.Dominio;
using Api.Persistencia;
namespace Api.Funcionalidades.Categorias;

public interface ICategoriaService
{
    void CreateCategoria(CategoriaDto categoriaDto);
    void DeleteCategoria(Guid IdCategoria);
    void UpdateCategoria(Guid Idcategoria, CategoriaDto categoriaDto);
    List<Categoria> GetCategorias();
}
public class CategoriaService : ICategoriaService
{
    private readonly TiendaOnlineDbContext context;
    public CategoriaService(TiendaOnlineDbContext context)
    {
        this.context = context;
    }

    public void CreateCategoria(CategoriaDto categoriaDto)
    {
        context.Categorias.Add(new Categoria(categoriaDto.Nombre, categoriaDto.Descripcion));

        context.SaveChanges();
    }

    public void DeleteCategoria(Guid IdCategoria)
    {
        var categoria = context.Categorias.FirstOrDefault(x => x.Id == IdCategoria);

        if (categoria != null)
        {
            context.Remove(categoria);

            context.SaveChanges();
        }
    }

    public List<Categoria> GetCategorias()
    {
        return context.Categorias.ToList();
    }

    public void UpdateCategoria(Guid Idcategoria, CategoriaDto categoriaDto)
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