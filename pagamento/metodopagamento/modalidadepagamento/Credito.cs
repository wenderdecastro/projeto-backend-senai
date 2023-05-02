using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metodo_Pagamento;

namespace Modalidade_Pagamento
{
    public class Credito : Cartao
    {
        //propriedade limite
        public float Limited { get; private set; } = 2000;
        ConsoleKeyInfo optionCredit;
        public float installments;
        public float valueinstallments;
        public float interestvalue;
        public override void Pagar(float valorInput)
        {
            do
            {

                if (valorInput > Limited)
                {
                    Console.WriteLine($"Tu usa nubank com 300 de limite amigão!! rsrs");
                    Console.WriteLine($"Tente outro valor para pagar por gentileza!");
                    break;
                }
                Console.WriteLine(@$"
            Selecione uma das opções abaixo:
            
            (1) - Pagamento a vista
            (2) - Pagamento parcelado
            ");
                this.optionCredit = Console.ReadKey(true);

                switch (optionCredit.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine($"Você selecionou pagamento a vista no cartão de credito.");
                        Console.WriteLine($"Como já foi feito o cadastro do cartão, o valor será cobrado na proxima fatura.");
                        Console.WriteLine($"Pagamento efutuado!");
                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine($"Digite a quantidade de parcelas: (1 - 12x)");
                        this.installments = float.Parse(Console.ReadLine());
                        if (installments <= 6)
                        {
                            Console.WriteLine($"Foi aplicado juros de 5% no valor total!");
                            interestvalue = (valorInput * 1.05f);
                            valueinstallments = this.interestvalue / this.installments;

                            Console.WriteLine($"O valor a pagar total no final em {installments}x é: {interestvalue:F2}");
                            Console.WriteLine($"O valor das prestações será: {valueinstallments:F2}");
                        }
                        else if (installments <= 12)
                        {
                            Console.WriteLine($"Foi aplicado juros de 8% no valor total!");
                            interestvalue = (valorInput * 1.08f);
                            valueinstallments = this.interestvalue / this.installments;

                            Console.WriteLine($"O valor a pagar total no final em {this.installments}x é: {this.interestvalue:F2}");
                            Console.WriteLine($"O valor das prestações será: {this.valueinstallments:F2}");
                        }
                        else
                        {
                            Console.WriteLine($"Aqui não é casas bahia não pô");
                            Console.WriteLine($"Tá duro dorme"); 
                        }
                            break;

                    default:
                        Console.WriteLine($"Esta opção nao é valida tente novamente");
                        break;
                }
            } while (optionCredit.Key != ConsoleKey.D1 && optionCredit.Key != ConsoleKey.D2);
        }
    }



}