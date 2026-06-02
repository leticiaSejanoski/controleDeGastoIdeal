using Microsoft.EntityFrameworkCore;
using CGI2.Models;

namespace CGI2.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext>
        options)
        : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; } //tabela Caterogias
        public DbSet<Gasto> Gastos { get; set; } //tabela Gastos
    }
}
