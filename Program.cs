using System;

class Program
{
    //Função para cadastrar gasto
    static void CadastrarGasto(List<Gasto> listaGastos)
    {
        Console.Write("Descrição: ");
        string descricao = Console.ReadLine();

        Console.Write("Valor: ");
        double valor = double.Parse(Console.ReadLine());

        Gasto gasto = new Gasto(descricao, valor);

        if (gasto.ValidaGasto())
        {
            listaGastos.Add(gasto);
        }
        else
        {
            Console.WriteLine("Erro! Descrição ou valor do gasto inválido.");
        }

        Console.WriteLine("------------------------");
    }

    //Função que lista os gastos
    static void ListarGastos(List<Gasto> listaGastos)
    {
        foreach (Gasto gasto in listaGastos)
        {
            Console.WriteLine(gasto.descricao + " - R$" + gasto.valor);
        }
    }

    static void Main(string[] args)
    {
        List<Gasto> listaGastos = new List<Gasto>();

        CadastrarGasto(listaGastos);
        ListarGastos(listaGastos);


    }
}
