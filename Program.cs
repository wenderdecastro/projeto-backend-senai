using Projeto_Backend_Senai;
using Metodo_Pagamento;
using Modalidade_Pagamento;

//INSTANCIAÇÃO DE CLASSES: 

Credito Credit = new Credito();
Debito Debit = new Debito();
Boleto BankSlip = new Boleto();

// Declaração de variáveis.

// bool fecharMenu = false;

// Variável que armazena o valor consoleKey que será utilizado no menu.
ConsoleKeyInfo opcao;

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
            // Payment.Cancelar();
            Console.WriteLine($"\n\nOperação Cancelada.");
            break;
        case ConsoleKey.D0:
            Console.WriteLine($"\n\nAplicativo de console do PayProject fechado!");
            Environment.Exit(0);
            break;
    }

} while (true);