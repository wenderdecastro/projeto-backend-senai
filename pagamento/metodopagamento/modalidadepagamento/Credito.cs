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

            void ConfirmarPagamento()
            {

                ConsoleKeyInfo opcaoConfirmar;

                do
                {
                    tool.Escrever(@$"

<@>Deseja confirmar o pagamento de {Math.Round(valorParcelas, 2).ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}? 

<@><@><+Green>[S] - Sim</>
<@><@><+Red>[N] - Não</>

");

                    opcaoConfirmar = Console.ReadKey(true);

                    if (opcaoConfirmar.Key == ConsoleKey.S)
                    {
                        pagamentoEfetuado = true;
                    }
                    else if (opcaoConfirmar.Key == ConsoleKey.N)
                    {
                        tool.Escrever("\n\nPagamento na modalidade Cartão de crédito <+Red>não efetuada</>.");
                        tool.Escrever("\n\n<=Red><$></>");
                        pagamentoEfetuado = false;
                    }
                    else
                    {
                        tool.Escrever("\n\n<+Red>Opção inválida</>, digite uma opção válida.\n");
                        tool.Escrever("\n<=Red><$></>");
                        pagamentoEfetuado = false;
                    }
                }
                while (opcaoConfirmar.Key != ConsoleKey.N && opcaoConfirmar.Key != ConsoleKey.S);
            }

            if (valorInput > limite)
            {
                tool.Escrever($"<@>\n<+Red>Não há limite suficiente.</> Limite atual: {Math.Round(limite, 2).ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
                pagamentoEfetuado = false;
                tool.Escrever("\n\n<=Red><$></>\n");

            }
            else
            {

                pagamentoEfetuado = false;

                tool.Escrever($"\n<@>Digite a quantidade de parcelas: (1 - 12x)");
                tool.Escrever("\n\n<@><@>");
                string input = Console.ReadLine();

                if (float.TryParse(input, out parcelas) && (parcelas > 0 && parcelas < 12))
                {
                    valorParcelas = valorInput / parcelas;

                    if (parcelas == 1)
                    {

                        tool.Escrever($"\n\nPagamento à vista, não será aplicado juros.");
                        ConfirmarPagamento();

                    }
                    else if (parcelas <= 6)
                    {
                        tool.Escrever($"Foi aplicado juros de 5% no valor total!");
                        juros = (valorInput * 1.05f);
                        valorParcelas = this.juros / this.parcelas;
                        ConfirmarPagamento();

                        tool.Escrever("\n<=Green><$></>\n\n");
                        tool.Escrever("<@>");
                        tool.Progresso();
                        tool.Escrever($"\n<@><+Green>Pagamento efetuado com sucesso!</> Obrigado por utilizar o Pay Project!");

                        tool.Escrever($"\n\n<@>Como já foi feito o cadastro do cartão, o valor será cobrado na proxima fatura.");
                        pagamentoEfetuado = true;
                    }
                    else if (parcelas <= 12)
                    {
                        tool.Escrever($"Foi aplicado juros de 8% no valor total!");
                        juros = (valorInput * 1.08f);
                        valorParcelas = this.juros / this.parcelas;
                        ConfirmarPagamento();

                        tool.Escrever("\n<=Green><$></>\n\n");
                        tool.Escrever("<@>");
                        tool.Progresso();
                        tool.Escrever($"\n<@><+Green>Pagamento efetuado com sucesso!</> Obrigado por utilizar o Pay Project!");

                        tool.Escrever($"\n\n<@>Como já foi feito o cadastro do cartão, o valor será cobrado na proxima fatura.");
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
            }
        }
    }
}