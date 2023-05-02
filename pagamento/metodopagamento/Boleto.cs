using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Backend_Senai;

namespace Metodo_Pagamento
{
    public class Boleto : Projeto_Backend_Senai.Pagamento
    {
        Ferramentas escreva = new Ferramentas();
        public bool escolhaPagamento;
        public double ValorPagamentoBoleto { get; set; }

        public Random CodigoDeBarras = new Random();

        public void Registrar(float valorInput)
        {

            ValorPagamentoBoleto = valorInput * 0.88;

            escreva.Escrever($"O valor do pagamento em boleto tem um <+Yellow> desconto de 12% do valor total </>, portanto, o valor com o desconto ficou de: <+Green>{Math.Round(ValorPagamentoBoleto, 2).ToString("C")} reais </>");

            escreva.Escrever($"O valor do código de barras de sua fatura é: <=Red>{CodigoDeBarras.Next(1000)}90.57670 {CodigoDeBarras.Next(100000)}.{CodigoDeBarras.Next(100000)} 7 {CodigoDeBarras.Next(100000)}.{CodigoDeBarras.Next(100000)} </>");

            do
            {
                escreva.Escrever(@" 
            Selecione:
           <+Blue> [1] </> - Para realizar o pagamento da fatura via boleto;
           <+Blue> [2] </> - Para voltar para o menu de escolha de pagamento; 
            ");
                ConsoleKeyInfo escolhaMenu = Console.ReadKey(true);

                //colocando readKey
                switch (escolhaMenu.Key)
                {
                    case ConsoleKey.D1:
                       
                        escreva.Escrever($"<+Green> Pagamento efetuado com sucesso! </> Obrigado por utilizar nosso programa!");
                        escolhaPagamento = true;

                        break;
                    case ConsoleKey.D2:

                        escreva.Escrever($"<+Red> Voce cancelou a operação de pagamento em Boleto </>, até mais!");
                        escolhaPagamento = true;

                        break;
                    default:

                        escreva.Escrever($"<+Red> Opção inválida, </> digite um valor conforme o menu!");
                        escolhaPagamento = false;

                        break;
                }


            } while (escolhaPagamento != true);
        }
    }
}