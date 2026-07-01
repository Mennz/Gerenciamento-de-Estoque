using System;

namespace GerenciamentoEstoqueAPI.Core.Interfaces
{
    public interface IAlertaServico
    {
        void DispararAlertaEstoqueBaixo(string nomeProduto, int estoqueAtual);
    }
}