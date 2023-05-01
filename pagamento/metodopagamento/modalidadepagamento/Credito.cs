using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metodo_Pagamento;

namespace Modalidade_Pagamento
{
    public class Credito : Cartao
    {
        //propriedade limite
        public float limite { get; private set; } = 2000;

        public float parcelas;


        public float Credit()
        {
            Console.WriteLine($"Você selecionou credito como pagamento");

            Console.WriteLine($"Deseja parcelar o pagamento:? (s/n)");
            string response = Console.ReadLine().ToLower();

            if (response == "s")
            {
                Console.WriteLine($"Em quantas parcelas? Sabendo que o maximo é 12x");
                parcelas = float.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine($"Pagamento sem parcelas ");
            }

            switch (parcelas)
            {
                case <=6:
                    break;
                    
                    
                case <=12:
                    break;
                default:
                    break;
            }

            return 0;
        }
    }
}