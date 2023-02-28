using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10ex1
{
    public interface IPlataContactFull : IPlata
    {
        void IntroduCard(IPlata element);
        bool EfectueazaPlata(double suma);
        void ExtrageCard();
    }
}
