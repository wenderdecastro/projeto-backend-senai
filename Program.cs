using Projeto_Backend_Senai;
using Metodo_Pagamento;
using Modalidade_Pagamento;

//teoricamente não é pra ter 2 classes abstratas instanciadas aqui

Credito credit = new Credito();
Debito debit = new Debito();
Boleto bankSlip = new Boleto();

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
