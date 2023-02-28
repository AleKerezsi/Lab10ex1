using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10ex1
{
    public class POS
    {
        public bool EsteCardulIntrodus { get; set; }

        private IPlataContactFull CardIntrodus { get; set; }

        public void IntroduCard(IPlataContactFull card) 
        {
            CardIntrodus = card;
            EsteCardulIntrodus = true;
        }

        public IPlataContactFull ExtrageCard() 
        {
            if (EsteCardulIntrodus)
            {
                EsteCardulIntrodus = false;
                return CardIntrodus;
            }
            else
            {
                Console.WriteLine("POS-ul nu are niciun card introdus.");
                return null;
            }
        }

        
        public bool Plateste(double suma, IPlataContactFull dispozitiv) 
        {
            if (EsteCardulIntrodus == false)
            {
                Console.WriteLine("Va rugam introduceti mai intai cardul in POS.");
                return false;
            }

            return dispozitiv.EfectueazaPlata(suma);
        }
       
        public bool Plateste(double suma, IPlataContactless dispozitiv)
        {
            dispozitiv.Apropie();

            return dispozitiv.EfectueazaPlata(suma);
        }
    }
}
