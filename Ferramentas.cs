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
        public void Progresso()
        {
            int progressoTotal = 100;

            for (int progresso = 0; progresso <= progressoTotal; progresso++)
            {
                // Faz o delay entre cada loop
                Thread.Sleep(10);

                // Calcula a porcentagem atual de progresso
                int porcentagem = (int)((float)progresso / progressoTotal * 100);

                // Exibe a barra de carregamento 
                Escrever($"\r<@>[<+Green>{new string('#', progresso / 5)}</>{new string('-', progressoTotal / 5 - progresso / 5)}] {porcentagem}%");
            }

            // Pula uma linha
            Console.WriteLine();
        }
    }
}