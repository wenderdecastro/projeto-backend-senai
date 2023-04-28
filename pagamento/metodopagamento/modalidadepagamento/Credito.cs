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
        public float limit { get; private set; } = 2000;
    }
}