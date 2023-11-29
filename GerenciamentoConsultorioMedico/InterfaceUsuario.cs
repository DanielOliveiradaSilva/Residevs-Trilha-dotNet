namespace GerenciamentoConsultorioMedico;
class InterfaceUsuario{


    public static void Main(){



        Medicos medicos = new Medicos("Daniel", DateTime.Parse("2000-01-01"), "12345678910", "123456789");
        medicos.adicionarPaciente();
        exibirMedicos(medicos);
        
    }

    public static void exibirMedicos( Medicos medicos) {
    
        System.Console.WriteLine("Lista de Medicos: ");
        foreach (var item in medicos.getMedicos())
        {
            
            System.Console.WriteLine($"{item.nome} - {item.dataNascimento} - {item.cpf} - {item.crm}");
        }
    }
 }
    