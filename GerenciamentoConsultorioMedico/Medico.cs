using System;
using System.Collections.Generic;

class Medicos : Pessoa {
    string crm;
    List<(string nome, DateTime dataNascimento, string cpf, string crm)> listaDeMedicos = new List<(string nome, DateTime dataNascimento, string cpf, string crm)>();

    public Medicos(string nome, DateTime dataNascimento, string cpf, string crm) {
        this.nome = nome;
        this.dataNascimento = dataNascimento;
        this.cpf = cpf;
        this.crm = crm;
    }
    
    public void adicionarPaciente() {
        listaDeMedicos.Add((this.nome, this.dataNascimento, this.cpf, this.crm));
    }
    public List<(string nome, DateTime dataNascimento, string cpf, string crm)> getMedicos() {
        return listaDeMedicos;
    }
}