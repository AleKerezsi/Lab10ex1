using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10ex1
{
    public interface IPlataContactless : IPlata
    {
        void Apropie();
        bool EfectueazaPlata(double suma);
    }
}
