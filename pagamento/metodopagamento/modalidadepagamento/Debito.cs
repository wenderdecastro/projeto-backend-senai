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
        public bool SaldoInsuficiente = false;
        public bool pagamentoEfetuado = false;
        private float saldo = 500;
        private ConsoleKeyInfo opcaoConfirmar;
        public override void Pagar(float valorInput)
        {
            float operacao = saldo - valorInput;

            if (valorInput > saldo)
            {
                tool.Escrever($"\n<+Red>Saldo insuficiente.</>\n");
                tool.Escrever("\n<=Green><$></>");
                SaldoInsuficiente = true;
            }
            else
            {
                tool.Escrever($"\nVocê está preste a pagar: R$<+Green>{valorInput}</>\n");
                tool.Escrever($"\nAo confirmar esse pagamento seu saldo restante será de R$<+Green>{operacao}</>");
                SaldoInsuficiente = false;
                do
                {
                    tool.Escrever(@$"

<@>Deseja confirmar o pagamento? 

<@><@>(S) - <+Green>Sim</>
<@><@>(N) - <+Red>Não</> ");

                opcaoConfirmar = Console.ReadKey(true);
                
                if(opcaoConfirmar.Key == ConsoleKey.S)
                {
                    Console.WriteLine($"Pagamento efetuado no valor de {operacao}");
                    pagamentoEfetuado = true;
                }
                else if(opcaoConfirmar.Key == ConsoleKey.N)
                {
                    tool.Escrever("\n\nPagamento na modalidade Cartão de débito <+Red>não efetuada</>.");
                    pagamentoEfetuado = false;
                }

                }
                while(opcaoConfirmar.Key != ConsoleKey.N && opcaoConfirmar.Key != ConsoleKey.S);
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
