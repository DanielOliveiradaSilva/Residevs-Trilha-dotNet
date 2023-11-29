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
        Console.WriteLine("2 - Intervalo QTD Min e Max de Produtos");
        Console.WriteLine("3 - Limitar qtd de Produtos em Estoque");  
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
    public static void  cadastrarProduto(Estoque gerenciarEstoque){
        // Requesting user input for the product details
        int codigo = ObterInput<int>("Digite o código do produto: ");
        string produto = ObterInput<string>("Digite o nome do produto: ");
        int qtd = ObterInput<int>("Digite a quantidade do produto: ");
        float preco = ObterInput<float>("Digite o preço do produto: ");
        var novoProduto = (codigo, produto, qtd, preco);
        string mensagem = gerenciarEstoque.cadastrarProduto(novoProduto)?"Produto Cadastrado!":"Produto já cadastrado!";   
        Console.WriteLine(mensagem);
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
                //Cadastrar Produto
                    cadastrarProduto(gerenciarEstoque);
                    break;
                case "2" :
                //Consultar Produto

                   consultarProduto(gerenciarEstoque);
                  
                    break;
                case "3":
                //Atualização de Estoque:
                    atualizarEstoque(gerenciarEstoque);
                    break;
                case "4":
                //Relatórios:
                    SubMenu();
                    string escolha = ObterInput<string>("Digite uma Opção:")!;
                    relatorioProdutos(gerenciarEstoque, escolha);
                    
                    break;
                case "5":
                continuar = false;
                    break;
                 
                default:
                    Console.Clear();
                    break;
            }
            
        }
       
    }
    public static void relatorioProdutos(Estoque gerenciarEstoque, string opcao){
        switch (opcao){
                        case "1":
                           
                            int limiteEstoque = ObterInput<int>("Informe o limite de estoque:");
                            exibirProdutoLimite(gerenciarEstoque, limiteEstoque);
                            break;
                        case "2":
                            int limiteMim = ObterInput<int>("Informe o limite de minimo:");
                            int limiteMax = ObterInput<int>("Informe o limite de maximo:");
                            exibirProdutoMinimoMaximo(gerenciarEstoque, limiteMim, limiteMax);
                            break;
                        case "3":
                           exibirTotalProdutos(gerenciarEstoque);
                            break;
                        default:
                            Console.Clear();
                            break;
                    }

    }
    public static void exibirTotalProdutos(Estoque gerenciarEstoque)
    {
        Console.WriteLine("\nItens em Estoque:");

        if (gerenciarEstoque.GetItensEstoque().Count == 0)
        {
            Console.WriteLine("Nenhum item encontrado no estoque.");
        }
        else
        {
            Console.WriteLine("| Código | Produto | Quantidade | Preço | Valor Total |");
            float valorTotalEstoque = 0;

            foreach (var item in gerenciarEstoque.GetItensEstoque())
            {
                float valorTotalProduto = item.qtd * item.preco;
                valorTotalEstoque += valorTotalProduto;

                Console.WriteLine($"| {item.codigo} | {item.produto} | {item.qtd} | {item.preco} | {valorTotalProduto} |");
            }

            Console.WriteLine($"\nValor total do estoque: {valorTotalEstoque}");
        }

        Console.WriteLine("\n");
    }
    
    public static void exibirProdutoMinimoMaximo(Estoque gerenciarEstoque, int min, int max){
        var produtosNoIntervalo = gerenciarEstoque.GetItensEstoque().Where(p => p.qtd >= min && p.qtd <= max).ToList();
        exibirProdutos(produtosNoIntervalo);
    }
    public static void exibirProdutoLimite(Estoque gerenciarEstoque, int limiteEstoque)
    {
        var produtosAbaixoLimite = gerenciarEstoque.GetItensEstoque().Where(p => p.qtd < limiteEstoque).ToList();
        exibirProdutos(produtosAbaixoLimite);
    }

    public static void exibirProdutos(List<(int codigo, string produto, int qtd, float preco)> produtos)
    {
        Console.WriteLine("\nItens em Estoque:");

        if (produtos.Count == 0){
            Console.WriteLine("Nenhum item encontrado no estoque.");
        }
        else{
            Console.WriteLine("| Código | Produto | Quantidade | Preço |");
            foreach (var item in produtos)
            {
                Console.WriteLine($"| {item.codigo} | {item.produto} | {item.qtd} | {item.preco} | ");
            }
        }

        Console.WriteLine("\n");
    }

    public static void consultarProduto(Estoque gerenciarEstoque){
        int codigo = ObterInput<int>("Digite o Codigo:");
        bool produtoEncontrado = false;

        foreach (var item in gerenciarEstoque.GetItensEstoque()) {
                if(item.codigo  == codigo){
                    Console.WriteLine($"\nItem em Estoque:");
                    Console.WriteLine($"| {item.codigo} | {item.produto} | {item.qtd} | {item.preco} |\n ");
                   
                    produtoEncontrado = true;
                    break;
                }
        }
        if(!produtoEncontrado){
        Console.WriteLine("Produto não foi encontrado!");
        Console.WriteLine($"\n");
    }
       
    }

   public static void  atualizarEstoque(Estoque produto){
        int codigo = ObterInput<int>("Digite o Codigo:");
        int qtd = ObterInput<int>("Digite a quantidade:");
        string mensagem = produto.atualizarEstoque(codigo, qtd)?"Estoque atualizado!":"Atualização Pendente!";
        Console.WriteLine(mensagem);
        
   }
}


