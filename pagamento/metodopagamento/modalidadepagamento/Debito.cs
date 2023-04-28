using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modalidade_Pagamento
{
    public class Debito
     {
    //         - Débito : valor á vista sem desconto
    //      - valor do saldo em conta deve ser pré-definido
        private float saldo;

        public float Depositar( float deposito)// Por causa da proteção do código, eu usei o if, dentro dele, determinei que Saldo = deposito, é importante determina um valor no "deposito" do "Program"
        {
            if( deposito > 0)
            {
                saldo = deposito;
                return saldo;
            }
            return 0;
        }
        // Saldo do Debito determinado, deixa que o clienta determine o saldo 
    }
}
