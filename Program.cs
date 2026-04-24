using System;
using System.Collections.Generic;

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

        int i = 1; 
        foreach (Gasto gasto in listaGastos)
        {
            Console.WriteLine($"{i} - {gasto.descricao} - R${gasto.valor} - {gasto.categoria.nome}");
            i++;
        }
    }

    //funçao que remove categorias e os gastos correspondentes
    static void RemoverCategoria(List<Categoria> categorias, List<Gasto> listaGastos)
    {
        if(categorias.Count == 0)
        {
            Console.WriteLine("Nenhuma categoria cadastrada.");
            return;            
        }

        Console.WriteLine("===== REMOVER CATEGORIAS =====");        
        Console.WriteLine("Qual categoria deseja remover?");

        int i = 1;   
        foreach (Categoria c in categorias)
        {
            Console.WriteLine($"{i} -" + c.nome);
            i++;
        }

        int opcaoRemover = int.Parse(Console.ReadLine());
        if (opcaoRemover < 1 || opcaoRemover > categorias.Count)
        {
            Console.WriteLine("Opção inválida!");
            return;
        }
        Categoria categoriaRemovida = categorias[opcaoRemover - 1];

        for (int j = listaGastos.Count - 1; j >= 0; j--) 
        {
            if (listaGastos[j].categoria == categoriaRemovida)
            {
                listaGastos.RemoveAt(j);
            }
        }
        categorias.RemoveAt(opcaoRemover - 1);
        Console.WriteLine("Categoria removida!");       
    }

    //função que remove gastos
    static void RemoverGasto(List<Gasto> listaGastos)
    {
        if(listaGastos.Count == 0)
        {
            Console.WriteLine("Nenhum gasto cadastrado.");
            return;
        }

        Console.WriteLine("===== REMOVER GASTOS =====");        
        Console.WriteLine("Qual gasto deseja remover?");

        ListarGastos(listaGastos);

        int opcaoRemover = int.Parse(Console.ReadLine());

        if (opcaoRemover < 1 || opcaoRemover > listaGastos.Count)
        {
            Console.WriteLine("Opção inválida!");
            return;
        }
        listaGastos.RemoveAt(opcaoRemover - 1);
        Console.WriteLine("Gasto removido!");
    }

    //função que soma os gastos (sem distinção de categorias)
    static void TotalGasto(List<Gasto> listaGastos)
    {
        if(listaGastos.Count == 0)
        {
            Console.WriteLine("Nenhum gasto cadastrado.");
            return;            
        }
        double soma = 0;
        Console.WriteLine("===== TOTAL DE GASTOS =====");
        for(int i = 0; i < listaGastos.Count; i++)
        {
            soma += listaGastos[i].valor;
        }
        Console.WriteLine($"Total de gastos: R$ ${soma:F2}");
    }

    //função que soma os gastos da mesma categoria
    static void TotalCategoria(List<Gasto> listaGastos, List<Categoria> categorias)
    {
        if (categorias.Count == 0)
        {
            Console.WriteLine("Nenhuma categoria cadastrada.");
            return;
        }
        Console.WriteLine("===== TOTAL POR CATEGORIA =====");
        for (int i = 0; i < categorias.Count; i++)
        {
            double soma = 0;
            for (int j = 0; j < listaGastos.Count; j++)
            {
                if (listaGastos[j].categoria == categorias[i])
                {
                    soma += listaGastos[j].valor;
                }
            }
            Console.WriteLine(categorias[i].nome + $": R$ ${soma:F2}");
        }
    }


    //enum para facilitar na construção do menu e recepção dos inputs
        enum menuOpcao
    {
        Cad_Categoria = 1,
        Cad_Gasto = 2,
        Listar_Categoria = 3,
        Listar_Gasto = 4,
        Total_Categoria = 5,
        Total_Gasto = 6,
        Remov_Categoria = 7,
        Remov_Gasto = 8,
        Sair = 0
    }

    //função que mostra o menu
    static void MostrarMenu()
    {
        Console.WriteLine("===== MENU =====");
        Console.WriteLine("[1] Cadastrar categoria");
        Console.WriteLine("[2] Cadastrar gasto");
        Console.WriteLine("[3] Listar categorias");
        Console.WriteLine("[4] Listar gastos");
        Console.WriteLine("[5] Total por categoria");
        Console.WriteLine("[6] Total de gastos");
        Console.WriteLine("[7] Remover categoria");        
        Console.WriteLine("[8] Remover gasto");
        Console.WriteLine("[0] Sair");                                           
    }

    static void Main(string[] args)
    {
        List<Categoria> categorias = new List<Categoria>();

        List<Gasto> listaGastos = new List<Gasto>();

        while (true)
        {
            MostrarMenu();
            int escolha = int.Parse(Console.ReadLine());
            menuOpcao opcao = (menuOpcao)escolha;
            switch (opcao)
            {
                case menuOpcao.Cad_Categoria:
                    CadastrarCategoria(categorias);
                    break;
                case menuOpcao.Cad_Gasto:
                    CadastrarGasto(listaGastos,categorias);
                    break;
                case menuOpcao.Listar_Categoria:
                    ListarCategorias(categorias);
                    break;
                case menuOpcao.Listar_Gasto:
                    ListarGastos(listaGastos);
                    break;
                case menuOpcao.Total_Categoria:
                    TotalCategoria(listaGastos, categorias);
                    break;                    
                case menuOpcao.Total_Gasto:
                    TotalGasto(listaGastos);
                    break;
                case menuOpcao.Remov_Categoria:
                    RemoverCategoria(categorias, listaGastos);
                    break;
                case menuOpcao.Remov_Gasto:
                    RemoverGasto(listaGastos);
                    break;
                case menuOpcao.Sair:
                    Console.WriteLine("Sistema encerrado!");
                    return;
                default:
                    Console.WriteLine("Entrada inválida!");
                    break;
            }
        }
    }

}


