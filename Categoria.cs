class Categoria{
    public string nome;

//construtor da classe categoria
 public Categoria(String nome){ 
    this.nome = nome;
}

//verifica se o nome da categoria é válido
 public bool ValidaCategoria(){
    if(this.nome == "" || this.nome == " "){
        return false;
    } else{
        return true;
    }
   
    }
}