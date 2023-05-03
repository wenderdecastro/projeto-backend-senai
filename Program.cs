using Projeto_Backend_Senai;
using Metodo_Pagamento;
using Modalidade_Pagamento;

//INSTANCIAÇÃO DE CLASSES: 

Credito Credit = new Credito();
Debito Debit = new Debito();
Boleto BankSlip = new Boleto();
Pagamento Payment = new Pagamento();
Ferramentas tool = new Ferramentas();

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
    tool.Escrever($"\n\n<@><@><+Green>Operação concluída.</>\n");
    Console.WriteLine(@"
        Deseja realizar uma nova operação?

            (S) - Sim
            (N) - Não ");
    do
    {
        opcaoNovaOperacao = Console.ReadKey(true);

        if (opcaoNovaOperacao.Key == ConsoleKey.S)
        {
            fecharMenu = true;
        }
        else if (opcaoNovaOperacao.Key == ConsoleKey.N)
        {
            tool.Escrever("\nObrigado por utilizar o sistema de pagamentos do <+Green>Pay Project</>!");

            tool.Escrever("\n\n<=Green><$></>"); // linha decorativa

            Environment.Exit(0);
        }
    } while (opcaoNovaOperacao.Key != ConsoleKey.S && opcaoNovaOperacao.Key != ConsoleKey.N);

    tool.Escrever("\n<=Green><$></>");
}
// Título do programa.
Console.WriteLine($"");

// Mudar cor do fundo do console
tool.Escrever("<=Green><$></>"); // linha decorativa

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

tool.Escrever("<=Green><$></>"); // linha decorativa
do
{
    while (!inputValido)
    {
        tool.Escrever($"\n\n<@>Insira a quantia que deseja pagar: ");
        tool.Escrever($"<@>"); // forma de alinhar o input para fins estéticos

        string input = Console.ReadLine();
        if (float.TryParse(input, out Payment.Valor) && Payment.Valor > 0)
        {
            tool.Escrever($"\n<@><@><+Green>Valor aceito!</> Você está prestes a pagar R$<+Green>{Payment.Valor}</>.\n");
            inputValido = true;
        }
        else
        {
            tool.Escrever("\n<@><@><+Red>Valor Invalido!</> Insira um valor válido para prosseguir.");
            inputValido = false;
        }
    }

    inputValido = false;

    // Laço de repetição para exibir o menu 
    tool.Escrever("\n<=Green><$></>");  // linha decorativa
    do
    {

        tool.Escrever(@$"

<@>Pressione o numero correspondente à operação desejada: 

<@><@>[1] - <+Green>Pagamento</> em boleto
<@><@>[2] - <+Green>Pagamento</> em cartão de crédito
<@><@>[3] - <+Green>Pagamento</> em cartão de débito
<@><@>[4] - <+Red>Cancelar</> operação

<@>[0] - Sair do sistema
    ");
        tool.Escrever("\n<=Green><$></>"); // linha decorativa

        // Leitura da tecla pressionada
        opcao = Console.ReadKey(true);

        switch (opcao.Key)
        {
            case ConsoleKey.D1:
                Console.WriteLine($"\n\nPagamento em Boleto Bancário selecionado.\n");
                BankSlip.Registrar(Payment.Valor);

                ConcluirOperacao();
                break;
            case ConsoleKey.D2:
                Credit.SalvarCartao();
                Credit.Pagar(Payment.Valor);

                ConcluirOperacao();
                break;
            case ConsoleKey.D3:
                Console.WriteLine($"\n\nPagamento em Cartão de Débito selecionado.");
                // Debit.SalvarCartao();
                Debit.Pagar(Payment.Valor);
                if (!Debit.SaldoInsuficiente)
                {
                    ConcluirOperacao();
                }
                else if (Debit.pagamentoEfetuado == true)
                {
                    ConcluirOperacao();
                }
                break;
            case ConsoleKey.D4:
                fecharMenu = true;
                tool.Escrever($"\n\n<@><+Red>{Payment.Cancelar(true)}</>\n");
                tool.Escrever("\n<=Green><$></>");
                break;
            case ConsoleKey.D0:
                tool.Escrever($"\n\n<@>Ao sair do sistema de pagamentos do Pay Project você cancelará a operação não finalizada e excluirá seus\ncartões salvos para compras futuras.");

                do
                {
                    tool.Escrever(@$"

<@>Deseja continuar?

<@><@><+Red>[S] - Sim</>
<@><@>[N] - Não
                ");
                    fecharMenu = false;
                    opcaoSair = Console.ReadKey(true);

                    if (opcaoSair.Key == ConsoleKey.S)
                    {
                        tool.Escrever($"\n<@><+Red>{Payment.Cancelar(true)}</>\n");

                        tool.Escrever("\nObrigado por utilizar o sistema de pagamentos do <+Green>Pay Project</>!");

                        tool.Escrever("\n\n<=Green><$></>"); // linha decorativa

                        Environment.Exit(0);
                    }
                    else if (opcaoSair.Key == ConsoleKey.N)
                    {
                        tool.Escrever("\n<=Green><$></>");
                    }

                } while (opcaoSair.Key != ConsoleKey.N);
                break;
        }

    } while (!fecharMenu);

} while (true);
