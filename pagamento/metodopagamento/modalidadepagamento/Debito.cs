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
        private float saldo = 500;
        private ConsoleKeyInfo opcaoConfirmar;
        public override void Pagar(float valorInput)
        {
            float operacao = saldo - valorInput;

            if (valorInput > saldo)
            {
                Console.WriteLine($"Saldo insuficiente.");
            }
            else
            {
                Console.WriteLine($"Você está preste a pagar: {valorInput}");
                Console.WriteLine($"Ao confirmar esse pagamento seu saldo restante será de {operacao}");
                
                do
                {
                    Console.WriteLine(@$"
                Deseja confirmar o pagamento? 
                (S) - Sim
                (N) - Não
                ");
                opcaoConfirmar = Console.ReadKey();
                
                if(opcaoConfirmar.Key == ConsoleKey.S)
                {
                    Console.WriteLine($"Pagamento efetuado no valor de {operacao}");
                }
                else if(opcaoConfirmar.Key == ConsoleKey.N)
                {
                    pay.Cancelar(true);
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
