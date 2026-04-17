using System;

class Program
{
    static void CadastrarCategoria(List<Categoria> categorias)
    {
        Console.WriteLine("\n===== CADASTRAR CATEGORIA =====");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Categoria categoria = new Categoria(nome);

        if (!categoria.ValidaCategoria())
        {
            Console.WriteLine("Nome da categoria inválido!");
            return;
        }
        //verifica nome de categoria duplicado
        foreach (Categoria c in categorias)
        {
            if (nome.ToLower() == c.nome.ToLower())
            {
                Console.WriteLine("Categoria já existe!");
                return;
            }
        }
        categorias.Add(categoria);
        Console.WriteLine("Categoria adicionada!");
    }
    static void ListarCategorias(List<Categoria> categorias)
    {
        //verifica se a lista está vazia
        if (categorias.Count == 0)
        {
            Console.WriteLine("Lista vazia!");
            return;
        }
        //mostra a lista
        Console.WriteLine("\n===== CATEGORIAS =====");
        foreach (Categoria c in categorias)
        {
            Console.WriteLine("-" + c.nome);
        }
    }

    //Função para cadastrar gasto
    static void CadastrarGasto(List<Gasto> listaGastos, List<Categoria> categorias)
    {
        Console.WriteLine("\n===== CADASTRAR GASTO =====");
        Console.Write("Descrição: ");
        string descricao = Console.ReadLine();

        Console.Write("Valor: ");
        double valor = double.Parse(Console.ReadLine());

        Console.WriteLine("Selecione uma categoria: ");
        if (categorias.Count == 0)
        {
            Console.WriteLine("Não há nenhuma categoria cadastrada.");
            return;
        }
        int i = 1;
        foreach (Categoria c in categorias)
        {
            Console.WriteLine($"[{i}]" + c.nome);
            i++;
        }

        int opcao = int.Parse(Console.ReadLine());
        Categoria categoriaSelecionada = categorias[opcao-1];


        Gasto gasto = new Gasto(descricao, valor, categoriaSelecionada);

        if (gasto.ValidaGasto())
        {
            listaGastos.Add(gasto);
            Console.WriteLine("Gasto adicionado!");
        }
        else
        {
            Console.WriteLine("Erro! Descrição ou valor do gasto inválido.");
        }
    }

    //Função que lista os gastos
    static void ListarGastos(List<Gasto> listaGastos)
    {
        Console.WriteLine("\n===== GASTOS =====");
        if (listaGastos.Count == 0)
        {
            Console.WriteLine("Nenhum gasto cadastrado.");
            return;
        }

        foreach (Gasto gasto in listaGastos)
        {
            Console.WriteLine($"{gasto.descricao} - R${gasto.valor} - {gasto.categoria.nome}");
        }
    }


    static void Main(string[] args)
    {
        List<Categoria> categorias = new List<Categoria>();

        List<Gasto> listaGastos = new List<Gasto>();

    }

}


