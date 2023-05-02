using Projeto_Backend_Senai;
using Metodo_Pagamento;
using Modalidade_Pagamento;

//INSTANCIAÇÃO DE CLASSES: 

Credito Credit = new Credito();
Debito Debit = new Debito();
Boleto BankSlip = new Boleto();
Pagamento Payment = new Pagamento();

// Declaração de variáveis.

// Váriaveis para loops
bool fecharMenu = false;
bool inputValido = false;
bool novaOperacao = false;
// Variaveis que armazenam o valor consoleKey que será utilizado em inputs no menu.
ConsoleKeyInfo opcao;
ConsoleKeyInfo opcaoSair;
ConsoleKeyInfo opcaoNovaOperacao;

// String para evitar a repetição de código
string linhaDecorativa = "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$";

// Declaração de funções


// Função para inserir cores de maneira mais facil no console

void Escrever(string msg)
{
    string[] seletor = msg.Split('<', '>');

    ConsoleColor cor;

    foreach (var texto in seletor)
        if (texto.StartsWith("/"))
            Console.ResetColor();
        else if (texto.StartsWith("=") && Enum.TryParse(texto.Substring(1), out cor))
            Console.BackgroundColor = cor;
        else if (texto.StartsWith("+") && Enum.TryParse(texto.Substring(1), out cor))
            Console.ForegroundColor = cor;
        else if (texto.StartsWith("$"))
            Console.Write(linhaDecorativa);
        else if (texto.StartsWith("@"))
            Console.Write($"    ");
        else
            Console.Write(texto);
}
// Título do programa.
Console.WriteLine($"");

// Mudar cor do fundo do console
Escrever("<=Green><$></>"); // linha decorativa

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

Escrever("<=Green><$></>"); // linha decorativa
do
{
    while (!inputValido)
    {
        Escrever($"\n\n<@>Insira a quantia que deseja pagar: ");
        Escrever($"<@>"); // forma de alinhar o input para fins estéticos

        string input = Console.ReadLine();
        if (float.TryParse(input, out Payment.Valor) && Payment.Valor > 0)
        {
            Escrever($"\n<@><@><+Green>Valor aceito!</> Você está prestes a pagar R$<+Green>{Payment.Valor}</>.\n");
            inputValido = true;
        }
        else
        {
            Escrever("\n<@><@><+Red>Valor Invalido!</> Insira um valor válido para prosseguir.");
            inputValido = false;
        }
    }

    inputValido = false;

    // Laço de repetição para exibir o menu 
    Escrever("\n<=Green><$></>");  // linha decorativa
    do
    {

        Escrever(@$"

<@>Pressione o numero correspondente à operação desejada: 

        (1) - <+Green>Pagamento</> em boleto
        (2) - <+Green>Pagamento</> em cartão de crédito
        (3) - <+Green>Pagamento</> em cartão de débito
        (4) - <+Red>Cancelar</> operação

<@>(0) - Sair do sistema
    ");
        Escrever("\n<=Green><$></>"); // linha decorativa

        // Leitura da tecla pressionada
        opcao = Console.ReadKey(true);

        switch (opcao.Key)
        {
            case ConsoleKey.D1:
                Console.WriteLine($"\n\nPagamento em Boleto Bancário selecionado.\n");
                BankSlip.Registrar(Payment.Valor);
                Console.WriteLine($"\nO código de barras do boleto gerado é: {BankSlip.CodigoDeBarras}");

                Escrever($"\n\n<@><@><+Green>Operação concluída.</>\n");
                Console.WriteLine(@"
        Deseja realizar uma nova operação?

            (S) - Sim
            (N) - Não ");
                do
                {
                    opcaoNovaOperacao = Console.ReadKey(true);

                    if (opcaoNovaOperacao.Key == ConsoleKey.S)
                    {
                        novaOperacao = true;
                        fecharMenu = true;
                    }
                    else if (opcaoNovaOperacao.Key == ConsoleKey.N)
                    {
                        Escrever("\nObrigado por utilizar o sistema de pagamentos do <+Green>Pay Project</>!");

                        Escrever("\n\n<=Green><$></>"); // linha decorativa

                        Environment.Exit(0);
                    }
                } while (opcaoNovaOperacao.Key != ConsoleKey.S && opcaoNovaOperacao.Key != ConsoleKey.N);

                Escrever("\n<=Green><$></>");
                break;
            case ConsoleKey.D2:
                Credit.SalvarCartao();
                Credit.Pagar(Payment.Valor);

                // do
                // {
                //     Console.WriteLine(@$"
                //     Você deseja salvar o cartão para compras futuras?
                //     • (S) - Sim
                //     • (N) - Não ");

                //     opcaoSalvar = Console.ReadKey(true);

                //     if (opcaoSalvar.Key == ConsoleKey.S)
                //     {

                //     }
                //     else
                //     {

                //     }
                // } while (opcaoSalvar.Key != ConsoleKey.N);

                break;
            case ConsoleKey.D3:
                Console.WriteLine($"\n\nPagamento em Cartão de Débito selecionado. FUNCAO EM DESENVOLVIMENTO");
                // Debit.SalvarCartao();
                Debit.Pagar(Payment.Valor);
                break;
            case ConsoleKey.D4:
                fecharMenu = true;
                Escrever($"\n\n<@><+Red>{Payment.Cancelar(true)}</>\n");
                Escrever("\n<=Green><$></>");
                break;
            case ConsoleKey.D0:
                Escrever($"\n\n<@>Ao sair do sistema de pagamentos do Pay Project você cancelará a operação não finalizada e excluirá seus\ncartões salvos para compras futuras.");

                do
                {
                    Escrever(@$"

    Deseja continuar?

        <+Red>(S) - Sim</>
        (N) - Não
                ");
                    opcaoSair = Console.ReadKey(true);

                    if (opcaoSair.Key == ConsoleKey.S)
                    {
                        Console.WriteLine("\n" + Payment.Cancelar(true));
                        Escrever("\nObrigado por utilizar o sistema de pagamentos do <+Green>Pay Project</>!");

                        Escrever("\n\n<=Green><$></>"); // linha decorativa

                        Environment.Exit(0);
                    }

                } while (opcaoSair.Key != ConsoleKey.N);
                break;
        }

    } while (!fecharMenu);

} while (true);
