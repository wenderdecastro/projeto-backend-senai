using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Backend_Senai
{
    public class Ferramentas
    {
        // String para evitar a repetição de código
        string linhaDecorativa = "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$";

        // Função para inserir cores de maneira mais facil no console
        public void Escrever(string msg)
        {
            string[] seletor = msg.Split('<', '>');

            ConsoleColor cor;

            foreach (var texto in seletor)
                if (texto.StartsWith("/"))
                    Console.ResetColor();
                else if (texto.StartsWith("=") && Enum.TryParse(texto.Substring(1), out cor))
                    Console.BackgroundColor = cor;
                else if (texto.StartsWith("+") && Enum.TryParse(texto.Substring(1), out cor))
                    Console.ForegroundColor = cor;
                else if (texto.StartsWith("$"))
                    Console.Write(linhaDecorativa);
                else if (texto.StartsWith("@"))
                    Console.Write($"    ");
                else
                    Console.Write(texto);
        }
    }
}