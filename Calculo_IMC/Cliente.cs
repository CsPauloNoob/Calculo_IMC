using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_IMC
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public double Peso { get; set; }

        public double Altura { get; set; }

        public double IMC { get; set; }
    }
}
