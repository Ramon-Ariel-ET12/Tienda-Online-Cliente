using Aplicacion.Dominio;
namespace Api.Funcionalidades.Categorias;

public interface ICategoriaService
{
    List<Categoria> GetCategorias();
}
public class CategoriaService : ICategoriaService
{
    List<Categoria> categorias;
    public CategoriaService()
    {
        categorias = new List<Categoria>()
        {
            new Categoria("Deportes", "Todo lo que tiene que ver con deportes"),
            new Categoria("Juguetes", "Cosas para pibitos"),
            new Categoria("Electronicas", "Dispositivos electronicos que usas a diario")
        };
    }
    public List<Categoria> GetCategorias()
    {
        return categorias;
    }
}