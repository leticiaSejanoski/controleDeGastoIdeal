using Microsoft.EntityFrameworkCore;
using CGI2.Models;
using CGI2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDataContext>(options =>
    options.UseSqlite("Data Source=gastos.db"));

var app = builder.Build();


//listar categorias
app.MapGet("/categorias", (AppDataContext context) =>
{
    return context.Categorias.ToList();
});


//cadastrar categorias
app.MapPost("/categorias", (Categoria categoria, AppDataContext context) =>
{
    string erro = validarCategoria(context, categoria);

    if (erro != "") return Results.BadRequest(erro);
    
    context.Categorias.Add(categoria);
    context.SaveChanges();

    return Results.Created($"/categorias/{categoria.Id}", categoria); //(url, objeto)
});


//listar gastos
app.MapGet("/gastos", (AppDataContext context) =>
{
    return context.Gastos.Include(g => g.Categoria).ToList();  //buscar um Gasto, incluindo também a propriedade Categoria.
});


//cadastrar gasto
app.MapPost("/gastos", (Gasto gasto, AppDataContext context) =>
{
    string erro = validarGasto(context, gasto);

    if (erro != "") return Results.BadRequest(erro);

    context.Gastos.Add(gasto);
    context.SaveChanges();

    return Results.Created($"/gastos/{gasto.Id}", gasto); //(url, objeto)
});

//deletar gastos
app.MapDelete("/gastos/{id}", (AppDataContext context, int id) =>{
    Gasto gasto = context.Gastos.Find(id);
    
        if (gasto == null)
        {
           return Results.NotFound("Gasto não encontrado");

        }
            context.Gastos.Remove(gasto);
            context.SaveChanges();
            return Results.Ok("Gasto removido!");

});

//deletar categorias
app.MapDelete("/categorias/{id}", (AppDataContext context, int id) =>{
    Categoria categoria = context.Categorias.Find(id);
    
        if (categoria == null)
        {
           return Results.NotFound("Categoria não encontrada");

        }
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return Results.Ok("Categoria removida!");
});

//total de gastos
app.MapGet("/gastos/total", (AppDataContext context) =>
{
    double total = context.Gastos.Sum(g => g.Valor);

    return Results.Ok(total);
});


//total de gastos por categoria
app.MapGet("/categorias/{id}/total", (AppDataContext context, int id) =>
{
    var categoria = context.Categorias.FirstOrDefault(c => c.Id == id);

    if (categoria == null)
        return Results.NotFound();

    double total = context.Gastos.Where(g => g.CategoriaId == id).Sum(g => g.Valor);

    return Results.Ok(total);
});


app.Run();

static string validarCategoria(AppDataContext context, Categoria categoria)
{
    if (categoria.Nome.Trim() == "")
    {
        return "Insira um nome válido!";
    }
    //verifica nome de categoria duplicado
    foreach (Categoria c in context.Categorias)
    {
        if (c.Nome.Trim().ToLower() == categoria.Nome.Trim().ToLower())
        {
            return "Categoria já existe!";
        }
    }
    return "";
}

static string validarGasto(AppDataContext context, Gasto gasto)
{
    if (gasto.Descricao.Trim() == "") return "Insira uma descrição válida!"; //descricao vazia
    if (gasto.Valor <= 0) return "Insira um valor válido!"; //valor maior que 0

    if (gasto.CategoriaId <= 0) return "Informe uma categoria válida!"; //id valido da categorias
    var categoria = context.Categorias.Find(gasto.CategoriaId); //procura categoria

    if (categoria == null) return "Categoria não encontrada!";
    if (context.Categorias.Count() == 0) return "Não há categorias cadastradas!";

    return "";
}

 

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

