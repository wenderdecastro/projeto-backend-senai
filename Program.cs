using Projeto_Backend_Senai;
using Metodo_Pagamento;
using Modalidade_Pagamento;

//INSTANCIAÇÃO DE CLASSES: 

Credito Credit = new Credito();
Debito Debit = new Debito();
Boleto BankSlip = new Boleto();
Pagamento Payment = new Pagamento();

// Declaração de variáveis.


bool fecharMenu = false;

// Variaveis que armazenam o valor consoleKey que será utilizado em inputs no menu.
ConsoleKeyInfo opcao;
ConsoleKeyInfo opcaoSair;
ConsoleKeyInfo opcaoSalvar;

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
        else
            Console.Write(texto);
}
// Título do programa.
Console.WriteLine($"");

// Mudar cor do fundo do console
Escrever("<=Green>$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$</>"); // linha decorativa

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

Escrever("<=Green>$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$</>"); // linha decorativa
do
{
    Console.WriteLine($"\n\n    Insira a quantia que deseja pagar: \n");
    Console.Write($"        "); // forma de alinhar o input para fins estéticos

    Payment.Valor = float.Parse(Console.ReadLine());

    // Laço de repetição para exibir o menu 
        Escrever("<=Green>\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$</>");  // linha decorativa
    do
    {

        Escrever(@$"

    Pressione o numero correspondente à operação desejada: 

        • (1) - Pagamento em boleto
        • (2) - Pagamento em cartão de crédito
        • (3) - Pagamento em cartão de débito
        • (4) - <+DarkRed>Cancelar operação</>

    • (0) - Sair do sistema
    ");
        Escrever("\n<=Green>$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$</>"); // linha decorativa

        // Leitura da tecla pressionada
        opcao = Console.ReadKey(true);

        switch (opcao.Key)
        {
            case ConsoleKey.D1:
                Console.WriteLine($"\n\nPagamento em Boleto Bancário selecionado. FUNCAO EM DESENVOLVIMENTO");
                BankSlip.Registrar(Payment.Valor);
                break;
            case ConsoleKey.D2:
                Credit.Pagar(Payment.Valor);

                do
                {
                    Console.WriteLine(@$"
                    Você deseja salvar o cartão para compras futuras?
                    • (S) - Sim
                    • (N) - Não ");

                    opcaoSalvar = Console.ReadKey(true);

                } while (opcaoSalvar.Key != ConsoleKey.N);

                break;
            case ConsoleKey.D3:
                Console.WriteLine($"\n\nPagamento em Cartão de Débito selecionado. FUNCAO EM DESENVOLVIMENTO");
                // Debit.Pagar(Payment.Valor);
                break;
            case ConsoleKey.D4:
                Console.WriteLine($"\n\n{Payment.Cancelar(true)}");
                fecharMenu = true;
                break;
            case ConsoleKey.D0:
                Console.WriteLine($"\n\n    Ao sair do sistema de pagamentos do Pay Project você cancelará a operação não finalizada e removerá seus\ncartões para compras futuras.");

                do
                {
                    Escrever(@$"
    Deseja continuar?

        <+Red>• (S) - Sim</>
        • (N) - Não
                ");
                    opcaoSair = Console.ReadKey(true);

                    if (opcaoSair.Key == ConsoleKey.S)
                    {
                        Console.WriteLine(Payment.Cancelar(true));
                        Console.WriteLine($"Obrigado por utilizar o sistema de pagamentos do Pay Project! \n");

                        Escrever("<=Green>$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$</>"); // linha decorativa

                        Environment.Exit(0);
                    }

                } while (opcaoSair.Key != ConsoleKey.N);
                break;
        }

    } while (fecharMenu == false);
} while (true);
