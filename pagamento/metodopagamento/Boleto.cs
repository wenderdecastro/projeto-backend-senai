using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Backend_Senai;
using System.Globalization;

namespace Metodo_Pagamento
{
    public class Boleto : Projeto_Backend_Senai.Pagamento
    {
        Ferramentas tool = new Ferramentas();
        public bool escolhaPagamento;
        public double ValorPagamentoBoleto { get; set; }
        private ConsoleKeyInfo escolhaMenu;
        public Random CodigoDeBarras = new Random();

        public void Registrar(float valorInput)
        {

            ValorPagamentoBoleto = valorInput * 0.88;

            tool.Escrever($"\n<@>Ao realizar o pagamento com boleto, você recebe um <+Green>desconto de 12% do valor total</>, o valor final é de: <+Green>{Math.Round(ValorPagamentoBoleto, 2).ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}</>.");

            tool.Escrever($"\n\n<@>O código de barras do boleto é: <+Green>{CodigoDeBarras.Next(100000, 999999)}.{CodigoDeBarras.Next(10000, 99999)} {CodigoDeBarras.Next(100000, 999999)}.{CodigoDeBarras.Next(100000, 999999)} {CodigoDeBarras.Next(0, 9)} {CodigoDeBarras.Next(000000, 100000)}.{CodigoDeBarras.Next(000000, 100000)} </>");

            do
            {
                tool.Escrever(@"

<@>Deseja confirmar o pagamento? (S/N):

<@><@><+Green>[S] - Sim </>
<@><@><+Red>[N] - Não </>

            ");

                escolhaMenu = Console.ReadKey(true);

                //colocando readKey
                switch (escolhaMenu.Key)
                {
                    case ConsoleKey.S:
                        tool.Escrever("\n<=Green><$></>\n\n");
                        tool.Progresso();
                        tool.Escrever($"\n<@><+Green>Pagamento efetuado com sucesso!</> Obrigado por utilizar o Pay Project!");
                        break;
                    case ConsoleKey.N:
                        tool.Escrever($"\n<+Red>Voce cancelou a operação de pagamento em Boleto</>, até mais!");
                        break;
                    default:
                        tool.Escrever("\n<=Green><$></>");
                        tool.Escrever($"\n\n<+Red> Opção inválida! </>Pressione uma opção conforme o menu!");
                        tool.Escrever("\n\n<=Red><$></>");
                        break;
                }


            } while (escolhaMenu.Key != ConsoleKey.S && escolhaMenu.Key != ConsoleKey.N);
        }
    }
}