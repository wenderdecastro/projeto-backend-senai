using Projeto_Backend_Senai;
using Metodo_Pagamento;
using Modalidade_Pagamento;

//INSTANCIAÇÃO DE CLASSES: 

Credito Credit = new Credito();
Debito Debit = new Debito();
Boleto BankSlip = new Boleto();
Pagamento Payment = new Pagamento();

// Declaração de variáveis.

// bool fecharMenu = false;

// Variável que armazena o valor consoleKey que será utilizado no menu.
ConsoleKeyInfo opcao;
ConsoleKeyInfo opcaoSair;

// Título do programa.

Console.BackgroundColor = ConsoleColor.DarkGreen;

Console.Write("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$"); Console.ResetColor();

Console.WriteLine(@$"

 /$$$$$$$                           /$$$$$$$                                               /$$    
| $$__  $$                         | $$__  $$                                             | $$    
| $$  \ $$ /$$$$$$  /$$   /$$      | $$  \ $$ /$$$$$$   /$$$$$$   /$$  /$$$$$$   /$$$$$$$ /$$$$$$  
| $$$$$$$/|____  $$| $$  | $$      | $$$$$$$//$$__  $$ /$$__  $$ |__/ /$$__  $$ /$$_____/|_  $$_/  
| $$____/  /$$$$$$$| $$  | $$      | $$____/| $$  \__/| $$  \ $$  /$$| $$$$$$$$| $$        | $$    
| $$      /$$__  $$| $$  | $$      | $$     | $$      | $$  | $$ | $$| $$_____/| $$        | $$ /$$
| $$     |  $$$$$$$|  $$$$$$$      | $$     | $$      |  $$$$$$/ | $$|  $$$$$$$|  $$$$$$$  |  $$$$/
|__/      \_______/ \____  $$      |__/     |__/       \______/  | $$ \_______/ \_______/   \___/  
                    /$$  | $$                              /$$   | $$                              
                   |  $$$$$$/                              |  $$$$$$/                              
                    \______/                                \______/                               
");

Console.BackgroundColor = ConsoleColor.DarkGreen;

Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$"); Console.ResetColor();
do
{
    Console.WriteLine($"Insira a quantia que deseja pagar:");

    Payment.Valor = float.Parse(Console.ReadLine());
    
    // Laço de repetição para exibir o menu 
    do
    {
        Console.WriteLine(@$"
    Pressione o numero correspondente à operação desejada: 

    1 - Pagamento em boleto
    2 - Pagamento em cartão de crédito
    3 - Pagamento em cartão de débito
    4 - Cancelar operação

    0 - Sair do sistema
    ");

        // Leitura da tecla pressionada
        opcao = Console.ReadKey();

        switch (opcao.Key)
        {
            case ConsoleKey.D1:
                Console.WriteLine($"\n\nPagamento em Boleto Bancário selecionado. FUNCAO EM DESENVOLVIMENTO");
                // BankSlip.Registrar();
                break;
            case ConsoleKey.D2:
                Console.WriteLine($"\n\nPagamento em Cartão de Crédito selecionado. FUNCAO EM DESENVOLVIMENTO");
                // Credit.Pagar();
                break;
            case ConsoleKey.D3:
                Console.WriteLine($"\n\nPagamento em Cartão de Débito selecionado. FUNCAO EM DESENVOLVIMENTO");
                break;
            case ConsoleKey.D4:
                Console.WriteLine($"\n\n{Payment.Cancelar(true)}");
                break;
            case ConsoleKey.D0:
                Console.WriteLine($"\n\nAo sair do sistema de pagamentos do Pay Project você cancelará a operação não finalizada.");

                do
                {
                    Console.WriteLine(@$"Deseja continuar?
                (S) - Sim
                (N) - Não
                ");
                    opcaoSair = Console.ReadKey();

                    if (opcaoSair.Key == ConsoleKey.S)
                    {
                        Console.WriteLine(Payment.Cancelar(true));
                        Console.WriteLine($"Obrigado por utilizar o sistema de pagamentos do Pay Project!");
                        Environment.Exit(0);
                    }

                } while (opcaoSair.Key != ConsoleKey.N);
                break;
        }

    } while (true);
} while (true);
