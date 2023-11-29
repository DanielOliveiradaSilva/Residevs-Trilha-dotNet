namespace GerenciamentoConsultorioMedico;
class InterfaceUsuario{


    public static void Main(){



        Medicos medicos = new Medicos("Daniel", DateTime.Parse("2000-01-01"), "12345678910", "123456789");
        medicos.adicionarPaciente();
        exibirMedicos(medicos);
        Pacientes pacientes = new Pacientes("John Doe", DateTime.Parse("1990-01-01"), "1234567890", "Male", "Fever, Cough");
        exibirPacientes(pacientes);
    }

    public static void exibirPacientes(Pacientes pacientes) {
    
        System.Console.WriteLine("Lista de Pacientes: ");
        foreach (var item in pacientes.getPacientes())
        {
            
            System.Console.WriteLine($"{item.nome} - {item.dataNascimento} - {item.cpf} - {item.crm}");
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
    