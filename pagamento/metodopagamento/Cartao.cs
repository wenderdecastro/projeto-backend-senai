using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metodo_Pagamento
{
    public abstract class Cartao : Projeto_Backend_Senai.Pagamento
    {

        // Declaração dos atributos da Classe abstrata Cartao
         public string Bandeira {get; set;}
         public string NumeroCartao {get; set;}
         public string Titular {get; set;}
         public string Cvv {get; set;}

        // Declaração dos métodos da Classe Abstrata
         public void Pagar(float valorInput)
         {

         }

         public void SalvarCartao()
         {

         }
    }
}