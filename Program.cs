using Projeto_Backend_Senai;
using Metodo_Pagamento;
using Modalidade_Pagamento;
using System.Globalization;

//INSTANCIAÇÃO DE CLASSES: 

Credito Credit = new Credito();
Debito Debit = new Debito();
Boleto BankSlip = new Boleto();
Pagamento Payment = new Pagamento();
Ferramentas Tools = new Ferramentas();

// Declaração de variáveis.

// Váriaveis para loops
bool fecharMenu = false;
bool inputValido = false;

// Variaveis que armazenam o valor consoleKey que será utilizado em inputs no menu.
ConsoleKeyInfo opcao;
ConsoleKeyInfo opcaoSair;
ConsoleKeyInfo opcaoNovaOperacao;

// Declaração de funções

void ConcluirOperacao()
{
    Tools.Escrever("\n\n<=Green><$></>");
    Tools.Escrever($"\n\n<@><+Green>Operação concluída.</>\n");
    Tools.Escrever(@"
<@>Deseja realizar uma nova operação?

<@><@><+Green>[S] - Sim</>
<@><@><+Red>[N] - Não</>");
    Tools.Escrever("\n\n<=Green><$></>");
    do
    {
        opcaoNovaOperacao = Console.ReadKey(true);

        if (opcaoNovaOperacao.Key == ConsoleKey.S)
        {
            fecharMenu = true;
        }
        else if (opcaoNovaOperacao.Key == ConsoleKey.N)
        {
            Tools.Escrever("\n\n<@>Obrigado por utilizar o sistema de pagamentos do <+Green>Pay Project</>!");

            Tools.Escrever("\n\n<=Green><$></>"); // linha decorativa

            Environment.Exit(0);
        }
    } while (opcaoNovaOperacao.Key != ConsoleKey.S && opcaoNovaOperacao.Key != ConsoleKey.N);
}
// Título do programa.

// Mudar cor do fundo do console
Tools.Escrever("\n<=Green><$></>"); // linha decorativa

// texto feito com ascii text converter para fins estéticos

Console.WriteLine(@$"

 /$$$$$$$                              /$$$$$$$                                                     /$$    
| $$__  $$                            | $$__  $$                                                   | $$    
| $$  \ $$  /$$$$$$    /$$   /$$      | $$  \ $$  /$$$$$$    /$$$$$$   /$$   /$$$$$$    /$$$$$$$ /$$$$$$  
| $$$$$$$/ |____  $$  | $$  | $$      | $$$$$$$/ /$$__  $$  /$$__  $$ |__/  /$$__  $$  /$$_____/ |_  $$_/  
| $$____/   /$$$$$$$  | $$  | $$      | $$____/ | $$  \__/ | $$  \ $$  /$$ | $$$$$$$$ | $$         | $$    
| $$       /$$__  $$  | $$  | $$      | $$      | $$       | $$  | $$ | $$ | $$_____/ | $$         | $$ /$$
| $$      |  $$$$$$$  |  $$$$$$$      | $$      | $$       |  $$$$$$/ | $$ |  $$$$$$$ |  $$$$$$$   |  $$$$/
|__/       \_______/   \____  $$      |__/      |__/        \______/  | $$  \_______/  \_______/    \___/  
                       /$$  | $$                                /$$   | $$                              
                      |  $$$$$$/                               |  $$$$$$/                              
                       \______/                                 \______/                               
");

Tools.Escrever("<=Green><$></>"); // linha decorativa
do
{
    while (!inputValido)
    {
        Tools.Escrever($"\n\n<@>Insira a quantia que deseja pagar: ");
        Tools.Escrever($"<@>R$ <+Green>"); // forma de alinhar o input para fins estéticos

        string input = Console.ReadLine(); Tools.Escrever($"</>");
        if (float.TryParse(input, out Payment.Valor) && Payment.Valor > 0)
        {
            Tools.Escrever($"\n<@><@><+Green>Valor aceito!</> Você está prestes a pagar <+Green>{Math.Round(Payment.Valor, 2).ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}</>.\n");
            inputValido = true;
        }
        else
        {
            Tools.Escrever("\n<@><+Red>Valor Invalido!</> Insira um valor válido para prosseguir.");
            Tools.Escrever("\n\n<=Red><$></>");
            inputValido = false;
        }
    }

    inputValido = false;

    // Laço de repetição para exibir o menu 
    Tools.Escrever("\n<=Green><$></>");  // linha decorativa
    do
    {

        Tools.Escrever(@$"

<@>Pressione o numero correspondente à operação desejada: 

<@><@>[1] - <+Green>Pagamento</> em boleto
<@><@>[2] - <+Green>Pagamento</> em cartão de crédito
<@><@>[3] - <+Green>Pagamento</> em cartão de débito
<@><@>[4] - <+Red>Cancelar</> operação

<@>[0] - Sair do sistema
    ");
        Tools.Escrever("\n<=Green><$></>"); // linha decorativa

        fecharMenu = false;

        // Leitura da tecla pressionada
        opcao = Console.ReadKey(true);

        switch (opcao.Key)
        {
            case ConsoleKey.D1:
                Tools.Escrever($"\n\n<@>Pagamento em Boleto Bancário selecionado.\n");
                BankSlip.Registrar(Payment.Valor);
                if (BankSlip.pagamentoEfetuado)
                {
                    ConcluirOperacao();
                }
                break;
            case ConsoleKey.D2:
                if (Credit.cartaoCadastrado == true || Debit.cartaoCadastrado == true)
                {
                    Tools.Escrever(@$"

<@><@> A operação será feita no cartão:

<@><@><@> Bandeira do cartão: {Credit.Bandeira}

<@><@><@>Final do cartão: {Credit.FinalCartao} 

<=Green><$></>
");
                }
                else
                {
                    Credit.SalvarCartao();
                }
                Credit.Pagar(Payment.Valor);
                if (Credit.pagamentoConfirmado)
                {
                    ConcluirOperacao();
                }
                break;
            case ConsoleKey.D3:
                Tools.Escrever($"\n\n<@>Pagamento em Cartão de Débito selecionado.");
                if (Credit.cartaoCadastrado == true || Debit.cartaoCadastrado == true)
                {
                    Tools.Escrever(@$"

<@><@>A operação será feita no cartão:

<@><@><@>Bandeira do cartão: {Credit.Bandeira}

<@><@><@>Final do cartão: {Credit.FinalCartao} 

<=Green><$></>
");
                }
                else
                {
                    Credit.SalvarCartao();
                }
                Debit.Pagar(Payment.Valor);
                if (Debit.pagamentoEfetuado)
                {
                    ConcluirOperacao();
                }
                break;
            case ConsoleKey.D4:
                fecharMenu = true;
                Credit.cartaoCadastrado = false;
                Debit.cartaoCadastrado = false;
                Tools.Escrever($"\n\n<@><+Red>{Payment.Cancelar(true)}</>\n");
                Tools.Escrever("\n<=Green><$></>");
                break;
            case ConsoleKey.D0:
                Tools.Escrever($"\n\n<@>Ao sair do sistema de pagamentos do Pay Project você cancelará a operação não finalizada e excluirá seus\ncartões salvos para compras futuras.");

                do
                {
                    Tools.Escrever(@$"

<@>Deseja continuar?

<@><@><+Red>[S] - Sim</>
<@><@><+Green>[N] - Não</>
                ");
                    fecharMenu = false;
                    opcaoSair = Console.ReadKey(true);

                    if (opcaoSair.Key == ConsoleKey.S)
                    {
                        Tools.Escrever($"\n<@><+Red>{Payment.Cancelar(true)}</>");

                        Tools.Escrever("\n\n<=Green><$></>");

                        Tools.Escrever("\n\n<@>Obrigado por utilizar o sistema de pagamentos do <+Green>Pay Project</>!");

                        Tools.Escrever("\n\n<=Green><$></>"); // linha decorativa

                        Environment.Exit(0);
                    }
                    else if (opcaoSair.Key == ConsoleKey.N)
                    {
                        Tools.Escrever("\n<=Green><$></>");
                    }

                } while (opcaoSair.Key != ConsoleKey.N);
                break;
            default:
                Tools.Escrever($"\n\n<+Red> Opção inválida! </>Utilize as opções do menu! Pressione qualquer tecla para continuar...");
                Tools.Escrever("\n\n<=Red><$></>");
                Console.ReadKey();
                break;
        }

    } while (!fecharMenu);

} while (true);
