using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10ex1.Extensii
{
    public static class CasaDeMarcatExtensions
    {
        public static void ElibereazaBonFiscal(this CasaDeMarcat casa, Produs produs)
        {
            Console.WriteLine("Se elibereaza bon fiscal pentru produsul " + produs );
        }
    }
}
