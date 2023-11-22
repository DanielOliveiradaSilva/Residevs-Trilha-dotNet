using System;
using System.Collections.Generic;
using System.Linq;

class GerenciadorTarefas
{
    // Classe interna para representar uma Tarefa
    class Tarefa
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool Concluida { get; set; }
    }

    // Lista de tarefas
    private List<Tarefa> tarefas = new List<Tarefa>();

    // Método para criar uma nova tarefa
    public void CriarTarefa()
    {
        Console.WriteLine("Criar uma nova tarefa:");

        Console.Write("Título: ");
        string titulo = Console.ReadLine();

        Console.Write("Descrição: ");
        string descricao = Console.ReadLine();

        Console.Write("Data de vencimento (dd/mm/aaaa): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dataVencimento))
        {
            tarefas.Add(new Tarefa
            {
                Titulo = titulo,
                Descricao = descricao,
                DataVencimento = dataVencimento,
                Concluida = false
            });
            Console.WriteLine("Tarefa criada com sucesso!");
        }
        else
        {
            Console.WriteLine("Formato de data inválido. Tarefa não criada.");
        }
    }

    // Método para listar todas as tarefas
    public void ListarTodasTarefas()
    {
        Console.WriteLine("Lista de todas as tarefas:");
        foreach (var tarefa in tarefas)
        {
            Console.WriteLine($"Título: {tarefa.Titulo} | Descrição: {tarefa.Descricao} | Vencimento: {tarefa.DataVencimento.ToShortDateString()} | Concluída: {(tarefa.Concluida ? "Sim" : "Não")}");
        }
    }

    // Método para marcar uma tarefa como concluída
    public void MarcarComoConcluida()
    {
        Console.WriteLine("Digite o número da tarefa a ser marcada como concluída:");
        if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 0 && indice < tarefas.Count)
        {
            tarefas[indice].Concluida = true;
            Console.WriteLine("Tarefa marcada como concluída!");
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido.");
        }
    }

    // Método para listar tarefas pendentes
    public void ListarTarefasPendentes()
    {
        var tarefasPendentes = tarefas.Where(tarefa => !tarefa.Concluida).ToList();
        Console.WriteLine("Lista de tarefas pendentes:");
        foreach (var tarefa in tarefasPendentes)
        {
            Console.WriteLine($"Título: {tarefa.Titulo} | Descrição: {tarefa.Descricao} | Vencimento: {tarefa.DataVencimento.ToShortDateString()}");
        }
    }

    // Método para listar tarefas concluídas
    public void ListarTarefasConcluidas()
    {
        var tarefasConcluidas = tarefas.Where(tarefa => tarefa.Concluida).ToList();
        Console.WriteLine("Lista de tarefas concluídas:");
        foreach (var tarefa in tarefasConcluidas)
        {
            Console.WriteLine($"Título: {tarefa.Titulo} | Descrição: {tarefa.Descricao} | Vencimento: {tarefa.DataVencimento.ToShortDateString()}");
        }
    }

    // Método para excluir uma tarefa
    public void ExcluirTarefa()
    {
        Console.WriteLine("Digite o número da tarefa a ser excluída:");
        if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 0 && indice < tarefas.Count)
        {
            tarefas.RemoveAt(indice);
            Console.WriteLine("Tarefa excluída com sucesso!");
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido.");
        }
    }

    // Método para pesquisar tarefas por palavra-chave
    public int PesquisarTarefa(string palavraChave){
        Console.WriteLine($"Resultado da pesquisa por '{palavraChave}':");
        
        for (int i = 0; i < tarefas.Count; i++)
        {
            var tarefa = tarefas[i];
            
            if (tarefa.Titulo.Contains(palavraChave) || tarefa.Descricao.Contains(palavraChave))
            {
                Console.WriteLine($"Índice: {i} | Título: {tarefa.Titulo} | Descrição: {tarefa.Descricao} | Vencimento: {tarefa.DataVencimento.ToShortDateString()} | Concluída: {(tarefa.Concluida ? "Sim" : "Não")}");
                return i; // Retorna o índice da primeira tarefa encontrada
            }
        }

        // Se nenhuma tarefa for encontrada, retorne -1
        return -1;
    }


    // Método para exibir estatísticas das tarefas
    public void ExibirEstatisticas()
    {
        Console.WriteLine($"Número de tarefas concluídas: {tarefas.Count(tarefa => tarefa.Concluida)}");
        Console.WriteLine($"Número de tarefas pendentes: {tarefas.Count(tarefa => !tarefa.Concluida)}");

        if (tarefas.Any())
        {
            var tarefaMaisAntiga = tarefas.OrderBy(tarefa => tarefa.DataVencimento).First();
            var tarefaMaisRecente = tarefas.OrderByDescending(tarefa => tarefa.DataVencimento).First();

            Console.WriteLine($"Tarefa mais antiga: {tarefaMaisAntiga.Titulo} ({tarefaMaisAntiga.DataVencimento.ToShortDateString()})");
            Console.WriteLine($"Tarefa mais recente: {tarefaMaisRecente.Titulo} ({tarefaMaisRecente.DataVencimento.ToShortDateString()})");
        }
        else
        {
            Console.WriteLine("Não há tarefas registradas.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GerenciadorTarefas gerenciador = new GerenciadorTarefas();
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("\n=== Sistema de Gerenciamento de Tarefas ===");
            Console.WriteLine("1. Criar Tarefa");
            Console.WriteLine("2. Listar Todas as Tarefas");
            Console.WriteLine("3. Marcar Tarefa como Concluída");
            Console.WriteLine("4. Listar Tarefas Pendentes");
            Console.WriteLine("5. Listar Tarefas Concluídas");
            Console.WriteLine("6. Excluir Tarefa");
            Console.WriteLine("7. Pesquisar Tarefas por Palavra-chave");
            Console.WriteLine("8. Estatísticas");
            Console.WriteLine("9. Sair");
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out int escolha))
            {
                switch (escolha)
                {
                    case 1:
                        gerenciador.CriarTarefa();
                        break;
                    case 2:
                        gerenciador.ListarTodasTarefas();
                        break;
                    case 3:
                        Console.Write("Digite a palavra-chave: ");
                        string palavraChave = Console.ReadLine();
                        gerenciador.MarcarComoConcluida();

                        break;
                    case 4:
                        gerenciador.ListarTarefasPendentes();
                        break;
                    case 5:
                        gerenciador.ListarTarefasConcluidas();
                        break;
                    case 6:
                        gerenciador.ExcluirTarefa();
                        break;
                    case 7:
                        Console.Write("Digite a palavra-chave: ");
                        string palavraChave = Console.ReadLine();
                        gerenciador.PesquisarTarefas(palavraChave);
                        break;
                    case 8:
                        gerenciador.ExibirEstatisticas();
                        break;
                    case 9:
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }

        Console.WriteLine("Saindo do sistema de gerenciamento de tarefas...");
    }
}
