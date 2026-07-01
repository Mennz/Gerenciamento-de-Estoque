using System;
using GerenciamentoEstoqueAPI.Core.Interfaces;

namespace GerenciamentoEstoqueAPI.Infrastructure.Notifications
{
    public class ConsoleAlertaServico : IAlertaServico
    {
        public void DispararAlertaEstoqueBaixo(string nomeProduto, int estoqueAtual)
        {
            var corOriginal = Console.ForegroundColor;
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n========================================================");
            Console.WriteLine($"ALERTA DE ESTOQUE BAIXO: O produto '{nomeProduto}' atingiu o nível crítico.");
            Console.WriteLine($"Quantidade atual em estoque: {estoqueAtual} unidades.");
            Console.WriteLine("========================================================\n");
            
            Console.ForegroundColor = corOriginal; // Volta a cor padrão
        }
    }
}