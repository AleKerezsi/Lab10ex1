using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10ex1
{
    public class CardClasic : DispozitivPlatibil, IPlataContactFull
    {
        public CardClasic(double balanta) 
        {
            ContBancar = new ContBancar(balanta);
        }

        public void IntroduCard(IPlata element)
        {
            Console.WriteLine("Se introduce cardul clasic in aparatul POS");
        }

        /// <summary>
        /// Plateste prin introducerea cardului classic in POS
        /// </summary>
        /// <param name="suma"></param>
        /// <returns>True daca plata s-a efectuat cu succes, sau False daca nu s-a efectuat cu succes</returns>
        public bool EfectueazaPlata(double suma)
        {
            if (suma < 0) 
            {
                Console.WriteLine("Suma oferita de plata nu poate fi negativa.");
                return false;
            }

            //nu mai verificam daca exista ultimul produs scanat deoarece procesul de plata prin POS poate fi rulat si independent de un produs scanat

            Console.WriteLine("Se incearca efectuarea platii de " + suma + " lei prin intermediul cardului clasic ");

            if (suma > ContBancar.Balanta) 
            {
                Console.WriteLine("Ne pare rau, nu aveti suficiente fonduri.");
                return false;
            }

            if (suma <= ContBancar.Balanta) 
            {
                Console.WriteLine("S-a achitat pretul produsului cu succes.");
                ContBancar.Balanta = ContBancar.Balanta - suma;
                return true;
            }

            return false;
        }

        public void ExtrageCard()
        {
            Console.WriteLine("Se extrage cardul clasic din aparatul POS");
        }
    }
}
