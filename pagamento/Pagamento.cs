using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Backend_Senai
{
    public class Pagamento
    {
        //propriedades
        private DateTime Data = DateTime.Now;
        public float Valor;

        //metodos
        public string Cancelar(bool cancelar)
        {
            if (cancelar)
            {
                return "Operação cancelada com sucesso";
            }
            return "";
        }
    }
}