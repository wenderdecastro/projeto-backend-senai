using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metodo_Pagamento;
using Projeto_Backend_Senai;
using System.Globalization;

namespace Modalidade_Pagamento
{
    public class Debito : Cartao
    {
        Pagamento pay = new Pagamento();
        Ferramentas tool = new Ferramentas();
        public bool pagamentoEfetuado = false;
        private float saldo = 500;
        private ConsoleKeyInfo opcaoConfirmar;
        public override void Pagar(float valorInput)
        {
            float operacao = saldo - valorInput;
            pagamentoEfetuado = false;

            if (valorInput > saldo)
            {
                tool.Escrever($"\n\n<@><@><+Red>Saldo insuficiente.</> Saldo atual: <+Green>{Math.Round(saldo, 2).ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}</>");
                tool.Escrever("\n\n<=Red><$></>");
            }
            else
            {
                tool.Escrever($"\n<@>Você está preste a pagar: <+Green>{Math.Round(valorInput, 2).ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}</>\n");
                tool.Escrever($"\n<@>Ao confirmar esse pagamento seu saldo restante será de <+Green>{Math.Round(operacao, 2).ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}</>");

                do
                {
                    tool.Escrever(@$"

<@>Deseja confirmar o pagamento? 

<@><@><+Green>[S] - Sim</>
<@><@><+Red>[N] - Não</>");

                    opcaoConfirmar = Console.ReadKey(true);

                    if (opcaoConfirmar.Key == ConsoleKey.S)
                    {
                        tool.Escrever("\n\n<=Green><$></>\n\n");
                        tool.Progresso();
                        tool.Escrever($"\n<@>Pagamento no valor de <+Green>{Math.Round(operacao, 2).ToString("C", CultureInfo.GetCultureInfo("pt-BR"))} efetuado com sucesso!</> Obrigado por utilizar o PayProject!");
                        pagamentoEfetuado = true;
                        saldo = operacao;
                    }
                    else if (opcaoConfirmar.Key == ConsoleKey.N)
                    {
                        tool.Escrever("\n\nPagamento na modalidade Cartão de débito <+Red>não efetuada</>.");

                        tool.Escrever("\n\n<=Red><$></>");
                        pagamentoEfetuado = false;
                    }

                }
                while (opcaoConfirmar.Key != ConsoleKey.N && opcaoConfirmar.Key != ConsoleKey.S);
            }
        }
    }
}
