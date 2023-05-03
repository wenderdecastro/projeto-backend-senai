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
        //propriedade Limite
        public float Limite { get; private set; } = 2000;
        ConsoleKeyInfo optionCredit;

        public int Parcelas;
        public float ValorParcelas { get; private set; }
        public float Juros { get; private set; }

        public bool pagamentoConfirmado { get; private set; }

        public override void Pagar(float valorInput)
        {

            void ConfirmarPagamento()
            {

                ConsoleKeyInfo opcaoConfirmar;

                do
                {
                    tool.Escrever(@$"

<@>Deseja confirmar o pagamento de <+Green>{Math.Round(valorInput, 2).ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}</> em <+Green>{Parcelas}x</> de <+Green>{Math.Round(ValorParcelas, 2).ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}</>? 

<@><@><+Green>[S] - Sim</>
<@><@><+Red>[N] - Não</>

");

                    opcaoConfirmar = Console.ReadKey(true);

                    if (opcaoConfirmar.Key == ConsoleKey.S)
                    {
                        tool.Escrever("\n<=Green><$></>\n\n");
                        tool.Escrever("<@>");
                        tool.Progresso();
                        tool.Escrever($"\n<@><+Green>Pagamento efetuado com sucesso!</> Obrigado por utilizar o Pay Project!");

                        tool.Escrever($"\n\n<@>Como já foi feito o cadastro do cartão, o valor será cobrado na proxima fatura.");
                        pagamentoConfirmado = true;
                    }
                    else if (opcaoConfirmar.Key == ConsoleKey.N)
                    {
                        tool.Escrever("\n<@>Pagamento na modalidade Cartão de crédito <+Red>não efetuada</>.");
                        tool.Escrever("\n\n<=Red><$></>");
                        pagamentoConfirmado = false;
                    }
                    else
                    {
                        tool.Escrever("\n<@><+Red>Opção inválida</>, tecle uma opção válida.\n");
                        tool.Escrever("\n<=Red><$></>");
                        pagamentoConfirmado = false;
                    }
                }
                while (opcaoConfirmar.Key != ConsoleKey.N && opcaoConfirmar.Key != ConsoleKey.S);
            }



            if (valorInput > Limite)
            {
                tool.Escrever($"<@>\n<+Red>Não há limite suficiente para efetuar essa compra.</> Limite atual: {Math.Round(Limite, 2).ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
                pagamentoConfirmado = false;
                tool.Escrever("\n\n<=Red><$></>\n");

            }
            else
            {
                bool inputValido = false;
                string input;

                while (!inputValido)
                {
                    tool.Escrever($"\n<@>Digite a quantidade de Parcelas: (1 - 12x)");
                    tool.Escrever("\n\n<@><@>");

                    input = Console.ReadLine();

                    if (int.TryParse(input, out Parcelas) && Parcelas >= 1 && Parcelas <= 12)
                    {
                        inputValido = true;
                    }
                    else
                    {
                        tool.Escrever("\n<=Green><$></>\n");
                        tool.Escrever($"\n<@><+Red>Numero de parcelas inválido, tente novamente...</>");
                        tool.Escrever("\n\n<=Red><$></>\n");
                    }
                }

                if (Parcelas == 1)
                {

                    ValorParcelas = this.Juros / this.Parcelas;
                    tool.Escrever($"\n\nPagamento à vista, não será aplicado Juros.");
                    ConfirmarPagamento();


                }
                else if (Parcelas <= 6)
                {
                    tool.Escrever($"\n<@>Ao parcelar em {Parcelas}x serão aplicados Juros de 5% no valor total!");
                    Juros = (valorInput * 1.05f);
                    ValorParcelas = this.Juros / this.Parcelas;
                    ConfirmarPagamento();


                }
                else if (Parcelas <= 12)
                {
                    tool.Escrever($"\n<@>Ao parcelar em {Parcelas}x serão aplicados Juros de 8% no valor total!");
                    Juros = (valorInput * 1.08f);
                    ValorParcelas = this.Juros / this.Parcelas;
                    ConfirmarPagamento();


                }
            }
        }
    }
}