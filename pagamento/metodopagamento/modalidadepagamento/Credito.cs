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
        string optionCredit;
        public float installments;
        public float valueinstallments;
        public float interestvalue;
        public override void Pagar(float valorInput)
        {
            do
            {
                Console.WriteLine(@$"
            Selecione uma das opções abaixo:
            '1' para pagamento a vista
            '2'para pagamento parcelado
            ");
                this.optionCredit = Console.ReadLine();

                switch (optionCredit)
                {
                    case "1":
                        Console.WriteLine($"Você selecionou pagamento a vista no cartão de credito.");

                        Console.WriteLine($"Pagamento efutuado!");
                        Console.WriteLine($"Muito obrigado volte sempre!");
                        break;

                    case "2":
                        Console.WriteLine($"Digite a quantidade de parcelas: (1 - 12x)");
                        this.installments = float.Parse(Console.ReadLine());
                        if (installments <= 6)
                        {
                            Console.WriteLine($"Foi aplicado juros de 5% no valor total!");
                            interestvalue = (Valor * 0.05f) + Valor;
                            valueinstallments = this.interestvalue / this.installments;

                            Console.WriteLine($"O valor a pagar total no final em {installments}x é: {interestvalue:F2}");
                            Console.WriteLine($"O valor das prestações será: {valueinstallments:F2}");
                        }
                        else if (installments <= 12)
                        {
                            Console.WriteLine($"Foi aplicado juros de 8% no valor total!");
                            interestvalue = (Valor * 0.08f) + Valor;
                            valueinstallments = this.interestvalue / this.installments;

                            Console.WriteLine($"O valor a pagar total no final em {this.installments}x é: {this.interestvalue:F2}");
                            Console.WriteLine($"O valor das prestações será: {this.valueinstallments:F2}");
                        }
                        else
                        {
                            Console.WriteLine($"Aqui não é casas bahia não pô");
                            Console.WriteLine($"Tá duro dormex"); 
                        }
                            break;

                    default:
                        Console.WriteLine($"Esta opção nao é valida tente novamente");
                        break;
                }
            } while (optionCredit != "1" && optionCredit != "2");
        }
    }



}