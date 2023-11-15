using Carter;
using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.Categorias;
public class CategoriaEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/Categoria", ([FromServices] ICategoriaService categoriaService) =>
        {
            return Results.Ok(categoriaService.GetCategorias());
        });

        app.MapPost("/api/Categoria", ([FromServices] ICategoriaService categoriaService, CategoriaDto categoriaDto) => {
            categoriaService.CreateCategoria(categoriaDto);
            
            return Results.Ok();
        });

        app.MapPut("/api/Categoria{Idcategoria}", ([FromServices] ICategoriaService categoriaService, Guid Idcategoria, CategoriaDto categoriaDto) => {
            categoriaService.UpdateCategoria(Idcategoria, categoriaDto);

            return Results.Ok();
        });

        app.MapDelete("/api/Categoria{Idcategoria}", ([FromServices] ICategoriaService categoriaService, Guid Idcategoria) => {
            categoriaService.DeleteCategoria(Idcategoria);

            return Results.Ok();
        });
    }
}