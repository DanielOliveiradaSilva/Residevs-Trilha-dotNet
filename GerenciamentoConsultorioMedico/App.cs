namespace GerenciamentoConsultorioMedico;
class App{

    public DateTime ObterDataNascimentoValida()
    {
        DateTime dataNascimento;
        bool dataValida = false;
        
        do
        {
            Console.Write("Digite a data de nascimento (dd/mm/aaaa): ");
            string input = Console.ReadLine();
            
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNascimento))
            {
                if (dataNascimento <= DateTime.Now)
                {
                    Console.WriteLine("Data de nascimento válida: " + dataNascimento.ToShortDateString());
                    dataValida = true;
                }
                else
                {
                    Console.WriteLine("Data de nascimento inválida. A data deve ser anterior ou igual à data atual.");
                }
            }
            else
            {
                Console.WriteLine("Formato de data inválido. Por favor, digite no formato correto (dd/mm/aaaa).");
            }
        } while (!dataValida);
        
        return dataNascimento;
    }
    public string ValidarStringVazia(string mensagem)
    {
        string str;
        do
        {
            Console.Write(mensagem);
            str = Console.ReadLine();
            
            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine("A string está vazia. Por favor, digite novamente.");
            }
        } while (string.IsNullOrEmpty(str));
        
        return str;
    }
    public string ValidarCPF(string mensagem){
    
        while (true){
            Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine();
            
            try
            {
                if (cpf.Length != 11)
                {
                    throw new ArgumentException("O CPF deve ter 11 dígitos");
                }
                
                if (!cpf.All(char.IsDigit))
                {
                    throw new ArgumentException("O CPF deve conter apenas dígitos");
                }
                
                if (cpf.Contains(".") || cpf.Contains(",") || cpf.Contains("-"))
                {
                    throw new ArgumentException("O CPF não deve conter pontos, vírgulas ou hífens");
                }
                
                return cpf;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

   

    public static void Main(){
        
        Medicos medicos = new Medicos("Daniel", DateTime.Parse("2000-01-01"), "12345678910", "123456789");
        medicos.adicionarMedico();
        exibirMedicos(medicos);

        // Pacientes pacientes = new Pacientes("John Doe", DateTime.Parse("1990-01-01"), "1234567890", "Male", "Fever, Cough");
        // pacientes.adicionarPaciente();
        // exibirPacientes(pacientes);
        
    }
    

    public static void exibirPacientes(Pacientes pacientes) {
    
        System.Console.WriteLine("Lista de Pacientes: ");
        foreach (var item in pacientes.getPacientes())
        {
            
            System.Console.WriteLine($"{item.nome} - {item.dataNascimento} - {item.cpf} - {item.sexo} - {item.sintomas}");
        }
    }


    public static void exibirMedicos( Medicos medicos) {
    
        System.Console.WriteLine("Lista de Medicos: ");
        foreach (var item in medicos.getMedicos())
        {
            
            System.Console.WriteLine($"{item.nome} - {item.dataNascimento} - {item.cpf} - {item.crm}");
        }
    }
 }
    