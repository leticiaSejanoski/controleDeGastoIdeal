using System;

namespace CGI2_API.Models
{
    public class Gasto
    {
        public int Id{ get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
