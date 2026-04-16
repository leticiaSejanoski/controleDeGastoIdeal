using System;
class Gasto
{
    public string descricao;
    public double valor;
    // private Categoria categoria;

    //cria construtor
    public Gasto(string descricao, double valor)
    {
        this.descricao = descricao;
        this.valor = valor;
    }

    //Verifica se os valores inseridos pelo usuário são válidos para adicionar na List
    public bool ValidaGasto()
    {
        if (this.descricao == "" || this.descricao == " " || this.valor <= 0) return false;
        else return true;
    }
}

