using System;
using System.Collections.Generic;

public class Estoque
{   
    //código do produto, nome do produto, quantidade em estoque e preço unitário.
    private List<(int codigo, string produto, int qtd, float preco)> itensEstoque = new();
    private List<(int Limite, int codigo, string produto)> limtesEstoque = new();
    
    public void AdicionarProduto((int codigo, string produto, int qtd, float preco) produto)
    {
        this.itensEstoque.Add(produto);
    }
     public List<(int codigo, string produto, int qtd, float preco)> GetItensEstoque()
    {
        return itensEstoque;
    }


}
