using System;
 
 class Program
    {

        static void ListarCategorias(List<Categoria> categorias){
            //verifica se a lista está vazia
            if(categorias.Count() == 0){
             Console.WriteLine("Lista vazia!");
             return;
            }
            //mostra a lista
            Console.WriteLine("\n===== CATEGORIAS =====");
              foreach(Categoria c in categorias){
              Console.WriteLine("-" + c.nome);
            }
           }

    static void CadastrarCategoria(List<Categoria> categorias)
    {
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
        if (listaGastos.Count == 0)
        {
             Console.WriteLine("Nenhum gasto cadastrado.");
             return;
        }

        foreach (Gasto gasto in listaGastos)
        {
            Console.WriteLine(gasto.descricao + " - R$" + gasto.valor);
        }
    }
    

        static void Main(string[] args)
        {
        List<Categoria> categorias = new List<Categoria>();

        List<Gasto> listaGastos = new List<Gasto>();
        }
        
    }
    

