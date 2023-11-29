using System;
using System.Collections.Generic;

public class Estoque
{   
    // código do produto, nome do produto, quantidade em estoque e preço unitário.
    private List<(int codigo, string produto, int qtd, float preco)> itensEstoque = new List<(int codigo, string produto, int qtd, float preco)>{
        (1, "Produto A", 10, 25.0f),
        (2, "Produto B", 15, 30.0f),
        (3, "Produto C", 20, 40.0f)
    };
    
    public bool cadastrarProduto((int codigo, string produto, int qtd, float preco) produto)
    {
        int indiceItem = itensEstoque.FindIndex(item => item.codigo == produto.codigo);

        if (indiceItem == -1)
        {
            itensEstoque.Add(produto);
            return true; // Retorna true se o produto foi adicionado com sucesso
        }
        else
        {
            return false; // Retorna false se o produto com o mesmo código já existe na lista
        }
    }
    

    public List<(int codigo, string produto, int qtd, float preco)> GetItensEstoque()
    {
        return itensEstoque;
    }

    public int pesquisarPorCodigo(int codigo)
    {
        for (int i = 0; i < itensEstoque.Count; i++)
        {
            if (itensEstoque[i].codigo == codigo)
            {
                return i;
            }
        }
        return -1;
    }

    public bool atualizarEstoque(int codigo, int novoQtd)
    {
        int indiceItem = itensEstoque.FindIndex(item => item.codigo == codigo);

        if (indiceItem != -1)
        {
            var itemAtualizado = itensEstoque[indiceItem];

            // Verificar se a nova quantidade é válida (maior ou igual a zero)
            if (itemAtualizado.qtd + novoQtd >= 0)
            {
                // Atualizar a quantidade do produto
                itemAtualizado.qtd += novoQtd;
                // Atualizar o item na lista
                itensEstoque[indiceItem] = itemAtualizado;
                return true;
            }
            else
            {
                // Se a nova quantidade for negativa e resultar em um estoque negativo, retorne false
                return false;
            }
        }
        else
        {
            // Se o item com o código especificado não foi encontrado na lista, retorne false
            return false;
        }
    }

}
