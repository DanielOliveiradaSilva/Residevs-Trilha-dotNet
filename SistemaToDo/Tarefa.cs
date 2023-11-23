public class Tarefa
    {
    
        private string Titulo { get;  set; }
        private string Descricao { get;  set; }
        private DateTime PrazoDeConclusao { get; set; }
        private bool Concluida { get; set; }

        // Lista para armazenar as tarefas

       
    public Tarefa(string titulo, string descricao, DateTime data){
           
        Titulo = titulo;
        Descricao = descricao;
        PrazoDeConclusao = data;
        Concluida = false;
    }

        // Métodos de acesso (getters e setters)
    public string GetTitulo()
    {
        return Titulo;
    }

    public void SetTitulo(string novoTitulo)
    {
        Titulo = novoTitulo;
    }

    public string GetDescricao()
    {
        return Descricao;
    }

    public void SetDescricao(string novaDescricao)
    {
        Descricao = novaDescricao;
    }

    public DateTime GetPrazoDeConclusao()
    {
        return PrazoDeConclusao;
    }

    public void SetPrazoDeConclusao(DateTime novaPrazoDeConclusao)
    {
        PrazoDeConclusao = novaPrazoDeConclusao;
    }

    public bool GetConcluida()
    {
        return Concluida;
    }

    public void SetConcluida(bool novaConcluida)
    {
        Concluida = novaConcluida;
    }
}


