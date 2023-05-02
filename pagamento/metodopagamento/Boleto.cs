using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Backend_Senai;

namespace Metodo_Pagamento
{
    public class Boleto : Projeto_Backend_Senai.Pagamento
    {
        public double ValorPagamentoBoleto {get; set;}

        public Random CodigoDeBarras {get; set;}

        public void Registrar(float valorInput){    
        
        //registrar o código do boleto
        
        ValorPagamentoBoleto = valorInput * 0.88;

        Console.WriteLine($"O valor do pagamento em boleto tem um desconto de 12% do valor total, portanto, o valor com o desconto ficou de: {ValorPagamentoBoleto}");
        

        }
    }
}