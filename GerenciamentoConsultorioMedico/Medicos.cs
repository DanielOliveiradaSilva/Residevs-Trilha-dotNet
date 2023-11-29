using System;
using System.Collections.Generic;

class Medicos : Pessoa {
    string crm;
   List<(string nome, DateTime dataNascimento, string cpf, string crm)> listaDeMedicos = new List<(string nome, DateTime dataNascimento, string cpf, string crm)>
    {
        ("Dr. John Smith", new DateTime(1980, 2, 15), "1234567890", "12345"),
        ("Dr. Jane Johnson", new DateTime(1975, 6, 20), "0987654321", "54321"),
        ("Dr. Mike Johnson", new DateTime(1982, 3, 15), "9876543210", "67890"),
        ("Dr. Emma Davis", new DateTime(1995, 7, 20), "5432109876", "98765")
    };
    public Medicos(string nome, DateTime dataNascimento, string cpf, string crm) {
        this.nome = nome;
        this.dataNascimento = dataNascimento;
        this.cpf = cpf;
        this.crm = crm;
    }
    
    public void adicionarMedico() {
        listaDeMedicos.Add((this.nome, this.dataNascimento, this.cpf, this.crm));
    }
    public List<(string nome, DateTime dataNascimento, string cpf, string crm)> getMedicos() {
        return listaDeMedicos;
    }
    List<(string nome, DateTime dataNascimento, string cpf, string sexo, string sintomas)> ObterMedicosComIdadeEntre(List<(string nome, DateTime dataNascimento, string cpf, string sexo, string sintomas)> pacientes, int idadeMinima, int idadeMaxima){
            DateTime hoje = DateTime.Today;
            return pacientes.Where(p => (hoje.Year - p.dataNascimento.Year) >= idadeMinima && (hoje.Year - p.dataNascimento.Year) <= idadeMaxima).ToList();
    }
}