namespace SistemaToDo;
class InterfaceUsuario{
    #region /menus de opçãos/
    public static void MenuOpcoes(){
       
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Cadastrar uma novo Produto");
        Console.WriteLine("2 - Consultar Produto");
        Console.WriteLine("3 - Atualizar Estoque");
        Console.WriteLine("4 - Relatorio de Produtos");
        Console.WriteLine("5 - Sair");
        Console.WriteLine("Digite uma Opção:");
    }

    public static void SubMenu(){
       
        Console.WriteLine("1 - Produtos abaixo da qtd min:");
        Console.WriteLine("1 - Intervalo QTD Min e Max de Produtos");
        Console.WriteLine("2 - Limitar qtd de Produtos em Estoque");  
    }
    
    #endregion
    #region /Template e validação de entrada de dados/
     public static T ObterInput<T>(string mensagem)
    {
        T valor;
        Console.Write(mensagem);
        while (!TryParse<T>(Console.ReadLine(), out valor))
        {
            Console.WriteLine("Por favor, insira um valor válido.");
            Console.Write(mensagem);
        }
        return valor;
    }

    public static bool TryParse<T>(string input, out T value)
    {
        try
        {
            if (typeof(T) == typeof(string))
            {
                value = (T)(object)input;
                return !string.IsNullOrEmpty(input);
            }
            else
            {
                value = (T)Convert.ChangeType(input, typeof(T));
                return true;
            }
        }
        catch
        {
            value = default(T);
            return false;
        }
    }
    #endregion
    public static void  adcionarProduto(Estoque gerenciarEstoque){
        // Requesting user input for the product details
        int codigo = ObterInput<int>("Digite o código do produto: ");
        string produto = ObterInput<string>("Digite o nome do produto: ");
        int qtd = ObterInput<int>("Digite a quantidade do produto: ");
        float preco = ObterInput<float>("Digite o preço do produto: ");

        var novoProduto = (codigo, produto, qtd, preco);
        gerenciarEstoque.AdicionarProduto(novoProduto);
    }
    public static void AppInterface(){
        
        bool continuar = true;
        //encapsulado
        
        Estoque gerenciarEstoque = new Estoque();
 
        while (continuar)
        {
            MenuOpcoes();
            string opcao = Console.ReadLine()!;
            switch (opcao){
                case "1":
                    adcionarProduto(gerenciarEstoque);
                    break;
                case "2":
                    
                   
                  
                    break;
                case "3":
                    
                    
                    break;
                case "4":
                    
                   
                    
                    break;
                case "5":
                   
                    break;
                 
                default:
   
                    break;
            }
            for (int i = 5; i > 0  ; --i)
            {
                Console.Write(".");
                Thread.Sleep(1000);
                
            }
           
            Console.Clear();
        }
       
    }

   
}


