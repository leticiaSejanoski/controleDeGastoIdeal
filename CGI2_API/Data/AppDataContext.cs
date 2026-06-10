using Microsoft.EntityFrameworkCore;
using CGI2_API.Models;

namespace CGI2_API.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext>
        options)
        : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; } //tabela Categorias
        public DbSet<Gasto> Gastos { get; set; } //tabela Gastos
    }
}
