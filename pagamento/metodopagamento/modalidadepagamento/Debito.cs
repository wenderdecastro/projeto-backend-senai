using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metodo_Pagamento;
using Projeto_Backend_Senai;

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
                tool.Escrever($"\n\n<@><@><+Red>Saldo insuficiente.</>");
                tool.Escrever("\n\n<=Green><$></>");
            }
            else
            {
                tool.Escrever($"\n<@>Você está preste a pagar: R$<+Green>{valorInput}</>\n");
                tool.Escrever($"\n<@>Ao confirmar esse pagamento seu saldo restante será de R$<+Green>{operacao}</>");

                do
                {
                    tool.Escrever(@$"

<@>Deseja confirmar o pagamento? 

<@><@><+Green>[S] - Sim</>
<@><@><+Red>[N] - Não</>");

                    opcaoConfirmar = Console.ReadKey(true);

                    if (opcaoConfirmar.Key == ConsoleKey.S)
                    {
                        tool.Escrever($"\n\nPagamento <+Green>efetuado</> no valor de R$<+Green>{operacao}</>");
                        pagamentoEfetuado = true;
                        saldo = operacao;
                    }
                    else if (opcaoConfirmar.Key == ConsoleKey.N)
                    {
                        tool.Escrever("\n\nPagamento na modalidade Cartão de débito <+Red>não efetuada</>.");

                        tool.Escrever("\n\n<=Green><$></>");
                        pagamentoEfetuado = false;
                    }

                }
                while (opcaoConfirmar.Key != ConsoleKey.N && opcaoConfirmar.Key != ConsoleKey.S);
            }


        }

        // public float Depositar(float deposito)// Por causa da proteção do código, eu usei o if, dentro dele, determinei que Saldo = deposito, é importante determina um valor no "deposito" do "Program"
        // {
        //     if (deposito > 0)
        //     {
        //         saldo = deposito;
        //         return saldo;
        //     }
        //     return 0;
        // }
        // Saldo do Debito determinado, deixa que o clienta determine o saldo 
    }
}
