using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Metodo_Pagamento
{
    public abstract class Cartao : Projeto_Backend_Senai.Pagamento
    {


        // Declaração dos atributos da Classe abstrata Cartao
        public string Bandeira { get; set; }
        public string NumeroCartao { get; set; }
        public static string Titular = "";
        public string Cvv { get; set; }


        //Declaração de um loopBreak apenas para essa classe.
        // private bool loopBreak = Regex.IsMatch(Titular, @"^[a-zA-Z]+$");

        // Declaração dos métodos da Classe Abstrata
        public abstract void Pagar(float valorInput);


        public string SalvarCartao()
        {

            Console.WriteLine(@$"
            
            MENU DE CADASTRO DE CARTÃO CRÉDITO/DÉBITO:
            
            ");



            Console.WriteLine(@$"
    Qual a bandeira do seu cartão?
            
        (1) - Visa
        (2) - MasterCard
        (3) - Elo
        (4) - HiperCard
            ");
            escolhaBandeira: 
            ConsoleKeyInfo escolhaBandeira = Console.ReadKey(true);

            switch (escolhaBandeira.Key)
            {
                case ConsoleKey.D1:
                Bandeira = "Visa";
                
                break;

                case ConsoleKey.D2:
                Bandeira = "MasterCard";
                break;

                case ConsoleKey.D3:
                Bandeira = "Elo";
                break;

                case ConsoleKey.D4:
                Bandeira = "HiperCard";
                break;
                    
                default:
                Console.WriteLine($"Opção inválida, digite uma opção válida.");
                
                goto escolhaBandeira;
            }
            

            Console.WriteLine($"Digite o número do seu cartão:");
            do
            {
                NumeroCartao = Console.ReadLine();

                if (!System.Text.RegularExpressions.Regex.IsMatch(NumeroCartao, "^[0-9]*$") || NumeroCartao.Length != 16)
                {

                    Console.WriteLine($"Número do cartão inválido. Por favor, digite um número de cartão válido.");

                }
            } while (NumeroCartao.Length != 16 || string.IsNullOrEmpty(NumeroCartao) || string.IsNullOrWhiteSpace(NumeroCartao) || !System.Text.RegularExpressions.Regex.IsMatch(NumeroCartao, "^[0-9]*$"));



            Console.WriteLine($"Digite o nome completo do titular do cartão (Mínimo de 8 caracteres):");

            do
            {
            Titular = Console.ReadLine();

            if (!Regex.IsMatch(Titular, @"^[a-zA-Z ]+$") && Titular.Length < 8 || string.IsNullOrEmpty(Titular) || string.IsNullOrWhiteSpace(Titular))
            {
            Console.WriteLine($"Nome inválido. Digite novamente");
            }
            else{

                Console.WriteLine($"Nome do titular cadastrado com sucesso!");
                break;
            }

            } while (Regex.IsMatch(Titular, @"^[a-zA-Z ]+$") || Titular.Length < 8);



            Console.WriteLine($"Digite o código de segurança do cartão:");

            do
            {

            Cvv = Console.ReadLine();

            if (!System.Text.RegularExpressions.Regex.IsMatch(Cvv, "^[0-9]*$") || Cvv.Length != 3)
            {
                Console.WriteLine($"Código de segurança inválido. Por favor, digite o código válido.");
                
            }
                
            } while (Cvv.Length != 3 || string.IsNullOrEmpty(Cvv) || string.IsNullOrWhiteSpace(Cvv) || !System.Text.RegularExpressions.Regex.IsMatch(Cvv, "^[0-9]*$"));

            String result = NumeroCartao.Substring(NumeroCartao.Length - 4);

            Console.WriteLine($"\nCARTÃO DO(A) TITULAR {Titular} SALVO COM SUCESSO!");

            Console.WriteLine($"Bandeira do cartão: {Bandeira}");
            Console.WriteLine($"Número do cartão: **** **** **** {result}");

            return "";
        }



    }
}