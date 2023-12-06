using Carter;
using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.Categorias;
public class CategoriaEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        #region Categoria
        app.MapGet("/api/categoria", ([FromServices] ICategoriaService categoriaService) =>
        {
            return Results.Ok(categoriaService.GetCategoria());
        });

        app.MapPost("/api/categoria", ([FromServices] ICategoriaService categoriaService, CategoriaCommandDto categoriaDto) =>
        {
            categoriaService.CreateCategoria(categoriaDto);
            return Results.Ok();
        });
        app.MapPut("/api/categoria/{Idcategoria}", ([FromServices] ICategoriaService categoriaService, CategoriaCommandDto categoriaDto, Guid Idcategoria) =>
        {
            categoriaService.UpdateCategoria(Idcategoria, categoriaDto);
            return Results.Ok();
        });
        app.MapDelete("/api/categoria/{Idcategoria}", ([FromServices] ICategoriaService categoriaService, Guid Idcategoria) =>
        {
            categoriaService.DeleteCategoria(Idcategoria);
            return Results.Ok();
        });
        #endregion
    }
}