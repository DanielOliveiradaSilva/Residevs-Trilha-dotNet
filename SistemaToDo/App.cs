namespace SistemaToDo;

class App {
    int tamanho = 0;
    private List<Tarefa> listaDeTarefas;

    public App(){
        listaDeTarefas  = new List<Tarefa>(); 
    }

    public App(List<Tarefa> tarefas)
    {
        listaDeTarefas = tarefas ?? new List<Tarefa>();
    }
    public bool adicionarTarefa(Tarefa tarefa){
        listaDeTarefas.Add(tarefa);
        if(tamanho < listaDeTarefas.Count){
            return true;
        }else{
            return false;

        }
    }

    // Getter para acessar a lista de tarefas
    public List<Tarefa> GetListaDeTarefas()
    {
        return listaDeTarefas;
    }

    public List<Tarefa> GetTarefasConcluidas(){
         return listaDeTarefas.Where(t => t.GetConcluida() == true).ToList();
    }

     public List<Tarefa> GetTarefasPendentes(){
        return listaDeTarefas.Where(t => t.GetConcluida() == false).ToList();
    }

    public int PesquisarPorPalavraChave(string palavraChave){
        string palavraChaveLowerCase = palavraChave.ToLower(); // Converter a palavra-chave para minúsculas

        for (int i = 0; i < listaDeTarefas.Count; i++)
        {
            string tituloTarefaLowerCase = listaDeTarefas[i].GetTitulo().ToLower(); // Converter o título da tarefa para minúsculas

            if (tituloTarefaLowerCase.Contains(palavraChaveLowerCase))
            {
                return i;
            }
        }

        // Retorna -1 se a palavra-chave não foi encontrada em nenhum título de tarefa
        return -1;
    }
    public bool MarcarComoConcluida(int indice){
        listaDeTarefas[indice].SetConcluida(true);
        return  listaDeTarefas[indice].GetConcluida()? true : false;
    }

    public  bool ExcluirTarefa(int indice){
        string palavra = listaDeTarefas[indice].GetTitulo();
        listaDeTarefas.RemoveAt(indice);
        bool confirmacao = PesquisarPorPalavraChave(palavra) == -1? true : false;
        return confirmacao;
    }

    public void Estatisticas(ref float total, ref float pendente, ref float concluido)
{
        total = listaDeTarefas.Count;
        pendente = listaDeTarefas.Count(t => !t.GetConcluida());
        concluido = listaDeTarefas.Count(t => t.GetConcluida());

       
    }

}