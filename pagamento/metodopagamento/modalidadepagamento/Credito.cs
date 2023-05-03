using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metodo_Pagamento;
using Projeto_Backend_Senai;
using System.Globalization;

namespace Modalidade_Pagamento
{
    public class Credito : Cartao
    {
        Ferramentas tool = new Ferramentas();
        //propriedade limite
        public float limite { get; private set; } = 2000;
        ConsoleKeyInfo optionCredit;
        public float parcelas;
        public float valorParcelas;
        public float juros;

        public bool pagamentoEfetuado;


        public override void Pagar(float valorInput)
        {
            do
            {
                if (valorInput > limite)
                {
                    tool.Escrever($"<@>\n<+Red>Não há limite suficiente.</> Limite atual {Math.Round(limite, 2).ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
                    pagamentoEfetuado = false;
                    tool.Escrever("\n\n<=Red><$></>");
                    break;
                }
                tool.Escrever(@$"
<@>Como deseja fazer o pagamento?
            
<@><@>[1] - Pagamento a vista
<@><@>[2] - Pagamento parcelado
            ");
                this.optionCredit = Console.ReadKey(true);
                pagamentoEfetuado = false;

                switch (optionCredit.Key)
                {
                    case ConsoleKey.D1:
                        tool.Escrever($"Você selecionou pagamento a vista no cartão de credito.");
                        tool.Progresso();
                        tool.Escrever($"Pagamento efetuado!");
                        tool.Escrever($"Como já foi feito o cadastro do cartão, o valor será cobrado na proxima fatura.");
                        pagamentoEfetuado = true;
                        break;

<<<<<<< HEAD
                case <= 12:
                    break;
                default:
                    break;
            }
            return 0;
=======
                    case ConsoleKey.D2:
                        tool.Escrever($"\n\nDigite a quantidade de parcelas: (1 - 12x)");
                        string input = Console.ReadLine();

                        if (float.TryParse(input, out parcelas) && parcelas > 0)
                        {
                            if (parcelas <= 6)
                            {
                                tool.Escrever($"Foi aplicado juros de 5% no valor total!");
                                juros = (valorInput * 1.05f);
                                valorParcelas = this.juros / this.parcelas;
                                tool.Progresso();

                                tool.Escrever($"O valor a pagar total no final em {parcelas}x é: {juros:F2}");
                                tool.Escrever($"O valor das prestações será: {valorParcelas:F2}");
                                tool.Escrever($"Pagamento efutuado!");
                                tool.Escrever($"Como já foi feito o cadastro do cartão, o valor será cobrado na proxima fatura.");
                                pagamentoEfetuado = true;
                            }
                            else if (parcelas <= 12)
                            {
                                tool.Escrever($"Foi aplicado juros de 8% no valor total!");
                                juros = (valorInput * 1.08f);
                                valorParcelas = this.juros / this.parcelas;
                                tool.Progresso();

                                tool.Escrever($"O valor a pagar total no final em {this.parcelas}x é: {this.juros:F2}");
                                tool.Escrever($"O valor das prestações será: {this.valorParcelas:F2}");
                                tool.Escrever($"Pagamento efutuado!");
                                tool.Escrever($"Como já foi feito o cadastro do cartão, o valor será cobrado na proxima fatura.");
                                pagamentoEfetuado = true;
                            }
                            else
                            {
                                tool.Escrever($"Nosso parcelamento máximo é de 12x com juros de 8%.");
                            }
                        }
                        else
                        {
                            tool.Escrever($"Insira um numero de parcelas válido.");
                        }

                        break;

                    default:
                        tool.Escrever($"Esta opção nao é valida tente novamente");
                        break;
                }
            } while (optionCredit.Key != ConsoleKey.D1 && optionCredit.Key != ConsoleKey.D2);
>>>>>>> 0f70ec6df54623c8fec200120bd320bb5a3034aa
        }
    }
}