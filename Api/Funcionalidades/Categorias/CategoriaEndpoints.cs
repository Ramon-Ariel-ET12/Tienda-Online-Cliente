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
            categoriaService.DaleteCategoria(Idcategoria);
            return Results.Ok();
        });
        #endregion
        #region LisProducto

        app.MapPost("/api/categoria/{Idcategoria}/producto/{productoid}", ([FromServices] ICategoriaService categoriaService, Guid Idcategoria, Guid productoid) =>
        {
            categoriaService.AddCategoria(Idcategoria, productoid);
            return Results.Ok();
        });
        app.MapDelete("/api/categoria/{Idcategoria}/producto/{productoid}/Delete", ([FromServices] ICategoriaService categoriaService, Guid Idcategoria, Guid productoid) =>
        {
            categoriaService.Daleteproducto(Idcategoria, productoid);
            return Results.Ok();
        });

        #endregion
    }
}