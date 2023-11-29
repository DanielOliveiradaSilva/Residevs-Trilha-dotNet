using System;
using System.Collections.Generic;

class Pacientes : Pessoa{
    string sexo;
    string sintomas;
    List<(string nome, DateTime dataNascimento, string cpf, string sexo, string sintomas)> listaDePacientes = new List<(string nome, DateTime dataNascimento, string cpf, string sexo, string sintomas)>
    {
    ("John Doe", new DateTime(1990, 1, 1), "1234567890", "Male", "Fever, Cough"),
    ("Jane Smith", new DateTime(1985, 5, 10), "0987654321", "Female", "Headache, Sore throat"),
    ("Mike Johnson", new DateTime(1982, 3, 15), "9876543210", "Male", "Fatigue, Fever"),
    ("Emma Davis", new DateTime(1995, 7, 20), "5432109876", "Female", "Nausea, Diarrhea")
    };
    Pacientes(string nome, DateTime dataNascimento, string cpf, string sexo, string sintomas){
        this.nome = nome;
        this.dataNascimento = dataNascimento;
        this.cpf = cpf;
        this.sexo = sexo;
        this.sintomas = sintomas;
    }

    public void adicionarPaciente(){
        listaDePacientes.Add((nome, dataNascimento, cpf, sexo, sintomas));
    }

    public List<(string nome, DateTime dataNascimento, string cpf, string sexo, string sintomas)> getPacientes() {
        return listaDePacientes;
    }
}