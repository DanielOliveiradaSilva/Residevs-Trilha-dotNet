namespace SistemaToDo;
class InterfaceUsuario{
    public static void MenuOpcoes(){
       
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Criar uma tarefa");
        Console.WriteLine("2 - Listar todas as tarefas");
        Console.WriteLine("3 - Marcar uma tarefa como concluída");
        Console.WriteLine("4 - Listar tarefas pendentes");
        Console.WriteLine("5 - Listar tarefas concluídas");
        Console.WriteLine("6 - Excluir uma tarefa");
        Console.WriteLine("7 - Exibir estatísticas");
        Console.WriteLine("8 - Sair");
        Console.WriteLine("Digite uma Opção:");
    }
   public static void  ConcluirTarefa(App minhasTarefas){
        string palavraChave = InterfaceUsuario.ObterInputString("Digite a tarefa: ");
        int index = minhasTarefas.PesquisarPorPalavraChave(palavraChave);
        if(index == -1){
            Console.WriteLine("Tarefa não encontrada");
            return;
        }else{
            string mensagem = minhasTarefas.MarcarComoConcluida(index) ? "Tarefa Concluída!" : "Marcação Pendente!";
            Console.WriteLine(mensagem);
        }
   }
   public static void ExcluirTarefa(App minhasTarefas){
        string palavraChave = InterfaceUsuario.ObterInputString("Digite a tarefa: ");
        int index = minhasTarefas.PesquisarPorPalavraChave(palavraChave);
        if(index == -1){
            Console.WriteLine("Tarefa não encontrada");
            return;
        }else{
             string mensagem = minhasTarefas.ExcluirTarefa(index) ? "Tarefa Concluída!" : "Remoção Pendente!";
             Console.WriteLine(mensagem);
        }
   }
    public static void AppInterface(){
        bool continuar = true;
        //encapsulado
        
        List<Tarefa> persistencia = new List<Tarefa>
        {
            new Tarefa("Tarefa 1", "Descrição da Tarefa 1", DateTime.Now.AddDays(1)),
            new Tarefa("Tarefa 2", "Descrição da Tarefa 2", DateTime.Now.AddDays(3)),
            new Tarefa("Tarefa 3", "Descrição da Tarefa 3", DateTime.Now.AddDays(5))
        };

        App minhasTarefas = new App(persistencia);

        while (continuar)
        {
            MenuOpcoes();
            string opcao = Console.ReadLine()!;
            switch (opcao){
                case "1":
                    string titulo = InterfaceUsuario.ObterInputString("Digite a tarefa: ");
                    string descricao = InterfaceUsuario.ObterInputString("Digite a descrição da tarefa: ");
                    DateTime prazo = InterfaceUsuario.ObterInputData("Digite o prazo da tarefa: ");
                    Tarefa novaTarefa = new Tarefa(titulo,descricao, prazo);
                    
                    if(minhasTarefas.adicionarTarefa(novaTarefa) == true){
                        Console.WriteLine("Tarefa adicionada com sucesso!");

                    }
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
                case "2":
                    
                    // Implemente a lógica para listar todas as tarefas aqui
                    listarTarefas(minhasTarefas.GetListaDeTarefas());
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
                case "3":
                    
                    // Implemente a lógica para marcar uma tarefa como concluída aqui
                        ConcluirTarefa(minhasTarefas);
                    break;
                case "4":
                    
                    // Implemente a lógica para listar tarefas pendentes aqui
                    listarTarefas(minhasTarefas.GetTarefasPendentes());
                    
                    break;
                case "5":
                   
                    // Implemente a lógica para listar tarefas concluídas aqui
                    listarTarefas(minhasTarefas.GetTarefasConcluidas());
                   
                    break;
                case "6":   
                    // Implemente a lógica para excluir uma tarefa aqui
                    ExcluirTarefa(minhasTarefas);
                    break;
                case "7":
                    // Implemente a lógica para exibir estatísticas aqui
                    ExibirEstatisticas(minhasTarefas);
                    break;
                case "8":
                    
                    continuar = false;
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

    public static string ObterInputString(string mensagem)
    {
        Console.Write(mensagem);
        string str = Console.ReadLine()!;
        return str;
    }

    public static double ObterInputDouble(string mensagem)
    {
        double valor;
        Console.Write(mensagem);
        while (!double.TryParse(Console.ReadLine(), out valor) || valor < 0)
        {
            Console.WriteLine("Por favor, insira um valor válido.");
            Console.Write(mensagem);
        }
        return valor;
    }
    public static DateTime ObterInputData(string mensagem)
    {
        DateTime data;
        do
        {
            Console.Write(mensagem);

            while (!DateTime.TryParse(Console.ReadLine(), out data))
            {
                Console.WriteLine("Por favor, insira uma data válida no formato dd/mm/aaaa.");
                Console.Write(mensagem);
            }

            if (data < DateTime.Today)
            {
                Console.WriteLine("Por favor, insira uma data anterior à data atual.");
                Thread.Sleep(2000);
                Console.Clear();
                
            }

        } while (data < DateTime.Today);
    
        return data;
    }
    public static void listarTarefas(List<Tarefa> tarefas)
    {
        Console.WriteLine("Minhas Tarefas:\n");
        if(tarefas.Count == 0){
            Console.WriteLine("Nenhuma tarefa encontrada.");
        }else{
             foreach (Tarefa tarefa in tarefas)
        {
             Console.WriteLine($"Tarefa:{tarefa.GetTitulo()}, Descricao:{tarefa.GetDescricao()}, Prazo:{tarefa.GetPrazoDeConclusao().ToShortDateString()}");
        }
        }
       
    }  

    public static void ExibirEstatisticas(App minhasTarefas)
    {
        float total = 0, pendente = 0, concluido = 0;
        
        minhasTarefas.Estatisticas(ref total, ref pendente, ref concluido);
        int qtr_pendete = (int)pendente;
        int qtd_concluida =(int) concluido;
        
        pendente = (pendente / total) * 100;
        concluido = (concluido / total) * 100;
        Console.WriteLine($"Tarefas pendentes: {pendente:F2}%, de {qtr_pendete} tarefas");
        Console.WriteLine($"Tarefas concluídas: {concluido:F2}%, de {qtd_concluida} tarefas");
        Console.WriteLine($"Total de tarefas: {total}");
       
    }
}


