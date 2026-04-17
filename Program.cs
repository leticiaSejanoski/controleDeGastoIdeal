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

        static void CadastrarCategoria(List<Categoria> categorias){
           Console.Write("Nome: ");
           string nome = Console.ReadLine();
           
           Categoria categoria = new Categoria(nome);

         if(!categoria.ValidaCategoria()){
            Console.WriteLine("Nome da categoria inválido!");
            return;
         }
           //verifica nome de categoria duplicado
           foreach(Categoria c in categorias){
            if(nome.ToLower() == c.nome.ToLower()){
            Console.WriteLine("Categoria já existe!");
            return;
        } 
    }
          categorias.Add(categoria);
          Console.WriteLine("Categoria adicionada!");
        }
    

        static void Main(string[] args)
        {
           List<Categoria> categorias = new List<Categoria>();
          
  
        }
        
    }
    
