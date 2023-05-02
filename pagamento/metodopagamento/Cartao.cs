using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metodo_Pagamento
{
    public abstract class Cartao : Projeto_Backend_Senai.Pagamento
    {

        // Declaração dos atributos da Classe abstrata Cartao
        public string Bandeira { get; set; }
        public string NumeroCartao { get; set; }
        public string Titular { get; set; }
        public string Cvv { get; set; }

        // Declaração dos métodos da Classe Abstrata
        public abstract void Pagar(float valorInput);

        public string SalvarCartao()
        {

            Console.WriteLine($"CADASTRO DE CARTÃO CRÉDITO/DÉBITO");


            Console.WriteLine($"Qual a bandeira do seu cartão?");   
            Bandeira = Console.ReadLine();

            do
            {
                Console.WriteLine($"Digite o número do seu cartão:");
                NumeroCartao = Console.ReadLine();

                if (NumeroCartao.Length != 16)
                {

                    Console.WriteLine($"Número do cartão inválido. Por favor, digite um número de cartão válido.");

                }
            } while (NumeroCartao.Length != 16);


            Console.WriteLine($"Digite o nome completo do titular do cartão:");
            Titular = Console.ReadLine();

            Console.WriteLine($"Digite o código de segurança do cartão:");
            Cvv = Console.ReadLine();


            return ($"CARTÃO DO(A) TITULAR {Titular} SALVO COM SUCESSO!");
        }



    }
}