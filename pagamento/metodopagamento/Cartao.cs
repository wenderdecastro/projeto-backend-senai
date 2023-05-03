using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Projeto_Backend_Senai;

namespace Metodo_Pagamento
{
    public abstract class Cartao : Projeto_Backend_Senai.Pagamento
    {
        Ferramentas tool = new Ferramentas();
        // Declaração dos atributos da Classe abstrata Cartao
        public string Bandeira { get; set; }
        public string NumeroCartao { get; set; }
        public string Titular;
        public string Cvv { get; set; }

        public bool cartaoCadastrado = false;

        // Declaração dos métodos da Classe Abstrata
        public abstract void Pagar(float valorInput);

        public string SalvarCartao()
        {
            Console.WriteLine(@$"
            
        MENU DE CADASTRO DE CARTÃO CRÉDITO/DÉBITO:");

            //Menu para o usuário visualizar e selecionar a informação que deseja adicionar sobre a bandeira.
            tool.Escrever(@"
<@>Qual a bandeira do seu cartão?
        
<@><@>[1] - <+Blue>Visa</>
<@><@>[2] - <+Red>Master</><+Yellow>Card</>
<@><@>[3] - <=Red>Hipercard</>
<@><@>[4] - <+Blue>Maes</><+Red>tro</>     ");

            tool.Escrever("\n\n<=Green><$></>");

        //Switch que vai derminar o valor que a variável Bandeira vai guardar.
        escolhaBandeira:
            ConsoleKeyInfo escolhaBandeira = Console.ReadKey(true);

            switch (escolhaBandeira.Key)
            {
                case ConsoleKey.D1:
                    Bandeira = "Visa";
                    break;

                case ConsoleKey.D2:
                    Bandeira = "MasterCard";
                    break;

                case ConsoleKey.D3:
                    Bandeira = "Elo";
                    break;

                case ConsoleKey.D4:
                    Bandeira = "HiperCard";
                    break;

                default:
                    tool.Escrever("\n\n<+Red>Opção inválida</>, digite uma opção válida.\n");
                    tool.Escrever("\n<=Red><$></>");

                    goto escolhaBandeira;
            }

            //Validação para que o usuário só consiga digitar números e só será aceito se o usuário digitar 16 números.
            tool.Escrever($"\n\n<@>Digite o número do seu cartão (**** **** **** ****):\n\n");

            do
            {
                tool.Escrever("<@><@>");
                NumeroCartao = Console.ReadLine();

                if (!System.Text.RegularExpressions.Regex.IsMatch(NumeroCartao, "^[0-9]*$") || NumeroCartao.Length != 16)
                {
                    tool.Escrever($"\n<@>Número do cartão <+Red>inválido</>. Por favor, digite um número de cartão válido:\n\n");
                }

                else
                {
                    tool.Escrever("\n<@><@><+Green>Número do cartão aceito!</>\n");
                }
            } while (NumeroCartao.Length != 16 || string.IsNullOrEmpty(NumeroCartao) || string.IsNullOrWhiteSpace(NumeroCartao) || !System.Text.RegularExpressions.Regex.IsMatch(NumeroCartao, "^[0-9]*$"));


            //Validação para que o usuário digite apenas letras, com um minimo de 8 caracteres.
            tool.Escrever($"\n<@>Digite o nome completo do titular do cartão (Mínimo de 8 caracteres):\n\n");


            do
            {
                tool.Escrever("<@><@>");
                Titular = Console.ReadLine();

                if (!Regex.IsMatch(Titular, @"^[a-zA-Z ]+$") || Titular.Length < 8 || string.IsNullOrEmpty(Titular) || string.IsNullOrWhiteSpace(Titular))

                {

                    tool.Escrever($"\n<@>Nome <+Red>inválido</>. Digite novamente\n\n");

                }
                else
                {

                    tool.Escrever($"\n<@><@><+Green>Nome do titular cadastrado com sucesso!</>\n");
                    break;
                }

            } while (!Regex.IsMatch(Titular, @"^[a-zA-Z ]+$") || Titular.Length < 8);


            // Mesma validação do número do cartão, mas aqui só é aceito 3 números
            tool.Escrever($"\n<@>Digite o código de segurança do cartão:\n");

            do
            {
                tool.Escrever("\n<@><@>");
                Cvv = Console.ReadLine();

                if (!System.Text.RegularExpressions.Regex.IsMatch(Cvv, "^[0-9]*$") || Cvv.Length != 3)
                {
                    tool.Escrever($"\n<@><@>Código de segurança <+Red>inválido</>. Por favor, digite o código válido.\n");

                }

                else
                {
                    tool.Escrever("\n<@><@><+Green>Código de segurança válido!</>\n");
                }

            } while (Cvv.Length != 3 || string.IsNullOrEmpty(Cvv) || string.IsNullOrWhiteSpace(Cvv) || !System.Text.RegularExpressions.Regex.IsMatch(Cvv, "^[0-9]*$"));

            String result = NumeroCartao.Substring(NumeroCartao.Length - 4);

            tool.Escrever($"\n<=Green><$></>");

            tool.Escrever($"\n\n<@><@>CARTÃO DO(A) TITULAR {Titular.ToUpper()} SALVO COM <+Green>SUCESSO</>!");

            tool.Escrever($"\n\n<@><@><@>Bandeira do cartão: {Bandeira}");
            tool.Escrever($"\n<@><@><@>Final do cartão: {result}");

            tool.Escrever($"\n\n<=Green><$></>\n");

            cartaoCadastrado = true;

            return "";
        }
    }
}