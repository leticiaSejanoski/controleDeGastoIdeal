using System;
class Gasto
{
    public string descricao;
    public double valor;
    public Categoria categoria;

    //cria construtor
    public Gasto(string descricao, double valor, Categoria categoria)
    {
        this.descricao = descricao;
        this.valor = valor;
        this.categoria = categoria;
    }
}

