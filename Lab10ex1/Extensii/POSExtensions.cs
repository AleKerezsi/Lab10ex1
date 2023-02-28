using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10ex1.Extensii
{
    public static class POSExtensions
    {
        public static void ElibereazaChitanta(this POS pos, Produs produs)
        {
            Console.WriteLine("Se elibereaza chitanta de la POS pentru produsul " + produs);
        }

    }
}
