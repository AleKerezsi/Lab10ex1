using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10ex1
{
    public class Produs
    {
        public string Nume { get; set; }
        public string Descriere { get; set; }
        public double Pret { get; set; }

        public override string ToString()
        {
            return $"[{Nume}, '{Descriere}', {Pret} lei]";
        }
    }
}
