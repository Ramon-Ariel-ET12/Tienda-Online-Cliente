using Aplicacion.Dominio;
using Api.Persistencia;
using Microsoft.EntityFrameworkCore;
using Api.Funcionalidades.Productos;
namespace Api.Funcionalidades.Categorias;

public interface ICategoriaService
{
    void AddCategoria(Guid Idcategoria, Guid productoid);
    void CreateCategoria(CategoriaCommandDto categoriaDto);
    void DaleteCategoria(Guid Idcategoria);
    void Daleteproducto(Guid Idcategoria, Guid productoid);
    List<CategoriaQueryDto>GetCategoria();
    void UpdateCategoria(Guid Idcategoria, CategoriaCommandDto categoriaDto);
}
public class CategoriaService : ICategoriaService
{
     private readonly TiendaOnlineDbContext context;
    public CategoriaService(TiendaOnlineDbContext context)
    {
        this.context = context;
    }

    public void AddCategoria(Guid Idcategoria, Guid productoid)
    {
        var categoria= context.Categorias.FirstOrDefault(x=>x.Id==Idcategoria);
        var producto = context.Productos.FirstOrDefault(x => x.Id ==productoid);
        if(categoria !=null && producto!=null)
        {
            categoria.AgregarProductos(producto);
            context.SaveChanges();
        }
    }

    public void CreateCategoria(CategoriaCommandDto categoriaDto)
    {
        context.Categorias.Add(new Categoria(categoriaDto.Nombre,categoriaDto.Descripcion));
        context.SaveChanges();
    }

    public void DaleteCategoria(Guid Idcategoria)
    {
        var categoria= context.Categorias.FirstOrDefault(x=>x.Id==Idcategoria);
        if(categoria !=null)
        {
            context.Remove(categoria);
            context.SaveChanges();
        }
    }

    public void Daleteproducto(Guid Idcategoria, Guid productoid)
    {
        var categoria= context.Categorias.Where(x=>x.Id==Idcategoria).Include(x => x.productos).First();
        var producto = categoria.productos?.FirstOrDefault(x => x.Id ==productoid);
        if(categoria !=null && producto!=null)
        {
            categoria.productos?.Remove(producto);
            context.SaveChanges();
        }
    }

    public List<CategoriaQueryDto>GetCategoria()
    {
        return context.Categorias.Include(x => x.productos)
        .Select(x=> new CategoriaQueryDto
        {
            Id=x.Id,
            Nombre=x.Nombre,
            Descripcion=x.Descripcion,
            Productos = x.productos.Select(y =>new ProductoQueryDto{Id=y.Id,Nombre=y.Nombre,Precio=y.Precio,Stock=y.Stock}).ToList()
        }).ToList();
    }   
    public void UpdateCategoria(Guid Idcategoria, CategoriaCommandDto categoriaDto)
    {
        var categoria= context.Categorias.FirstOrDefault(x=>x.Id==Idcategoria);
        if(categoria !=null)
        {
            categoria.Nombre=categoriaDto.Nombre;
            categoria.Descripcion=categoria.Descripcion;
            context.SaveChanges();
        }
    }
}