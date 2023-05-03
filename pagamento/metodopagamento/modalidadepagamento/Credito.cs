using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metodo_Pagamento;
using Projeto_Backend_Senai;

namespace Modalidade_Pagamento
{
    public class Credito : Cartao
    {
        Ferramentas tool = new Ferramentas();
        //propriedade limite
        public float Limited { get; private set; } = 2000;
        ConsoleKeyInfo optionCredit;
        public float parcelas;
        public float valorParcelas;
        public float juros;


        public override void Pagar(float valorInput)
        {
            do
            {
                if (valorInput > Limited)
                {
                    tool.Escrever("<+Red>Limite do cartão estourado!</>");
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
                        tool.Progresso();
                        Console.WriteLine($"Como já foi feito o cadastro do cartão, o valor será cobrado na proxima fatura.");
                        Console.WriteLine($"Pagamento efutuado!");
                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine($"Digite a quantidade de parcelas: (1 - 12x)");
                        this.parcelas = float.Parse(Console.ReadLine());
                        if (parcelas <= 6)
                        {
                            Console.WriteLine($"Foi aplicado juros de 5% no valor total!");
                            juros = (valorInput * 1.05f);
                            valorParcelas = this.juros / this.parcelas;

                            Console.WriteLine($"O valor a pagar total no final em {parcelas}x é: {juros:F2}");
                            Console.WriteLine($"O valor das prestações será: {valorParcelas:F2}");
                        }
                        else if (parcelas <= 12)
                        {
                            Console.WriteLine($"Foi aplicado juros de 8% no valor total!");
                            juros = (valorInput * 1.08f);
                            valorParcelas = this.juros / this.parcelas;

                            Console.WriteLine($"O valor a pagar total no final em {this.parcelas}x é: {this.juros:F2}");
                            Console.WriteLine($"O valor das prestações será: {this.valorParcelas:F2}");
                        }
                        else
                        {
                            Console.WriteLine($"Infelizmente não parcelamos mais do 12x");
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