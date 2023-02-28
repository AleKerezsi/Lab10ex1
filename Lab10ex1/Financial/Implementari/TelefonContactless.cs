using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10ex1
{
    public class TelefonContactless : DispozitivPlatibil, IPlataContactless
    {
        public TelefonContactless(double balanta) 
        {
            ContBancar = new ContBancar(balanta);
        }

        public void Apropie()
        {
            Console.WriteLine("Se apropie telefonul in modul de plata contactless de aparatul POS...");
        }

        public bool EfectueazaPlata(double suma)
        {
            if (suma < 0)
            {
                Console.WriteLine("Suma oferita de plata nu poate fi negativa.");
                return false;
            }

            //nu mai verificam daca exista ultimul produs scanat deoarece procesul de plata prin POS poate fi rulat si independent de un produs scanat

            Console.WriteLine("Se incearca efectuarea platii de " + suma + " lei prin intermediul cardului contactless ");

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
    }
}
