using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10ex1
{
    public class CasaDeMarcat
    {
        private bool SeifDeschis = false;

        private Produs UltimulProdusScanat { get; set; } = null;

        private POS Pos { get; set; }

        public CasaDeMarcat() 
        {
            Pos = new POS();
        }

        public void ScanareProdus(Produs produs)
        {
            Console.WriteLine("Se scaneaza produsul " + produs);
            UltimulProdusScanat = produs;
        }

        //public void ElibereazaBonFiscal(Produs produs) 
        //{
        //    Console.WriteLine("Elibereaza bon fiscal pentru produsul " + produs);
        //}

        /// <summary>
        /// Plateste cash pentru produs
        /// </summary>
        /// <param name="suma"></param>
        /// <returns>Restul pentru client, daca este aplicabil</returns>
        public (bool,double) Plateste(double suma)
        {
            Console.WriteLine("Se deschide seiful");
            SeifDeschis = true;

            Console.WriteLine("Clientul ofera suma de " + suma + " lei plata pentru produs.");

            if (UltimulProdusScanat != null)
            {
                if (suma < UltimulProdusScanat.Pret)
                {
                    Console.WriteLine("Pretul produsului este " + UltimulProdusScanat.Pret + " lei, dar clientul a platit doar " + suma + " lei. Nu este suficient.");
                    Console.WriteLine($"Se anuleaza produsul, si se returneaza {suma} lei inapoi clientului");
                    UltimulProdusScanat = null;
                    return (false,suma);
                }

                if (suma == UltimulProdusScanat.Pret)
                {
                    Console.WriteLine("S-a achitat pretul produsului cu succes.");
                    Console.WriteLine("Se introduce suma de " + suma + " lei in seif");
                    Console.WriteLine("Se inchide seiful");
                    SeifDeschis = false;
                    return (true,0.0);
                }


                if (suma > UltimulProdusScanat.Pret)
                {
                    double rest = suma - UltimulProdusScanat.Pret;
                    Console.WriteLine("S-a achitat pretul produsului cu succes.");
                    Console.WriteLine("Se returneaza " + rest + " lei rest la client.");
                    Console.WriteLine("Se introduce suma de " + suma + " lei in seif");
                    Console.WriteLine("Se inchide seiful");
                    SeifDeschis = false;
                    return (true,rest);
                }
            }
            else 
            {
                Console.WriteLine("Va rugam scanati un produs mai intai");
                Console.WriteLine("Se returneaza " + suma + " suma la client.");
                return (false,suma);
            }

            return (false,0.0);
        }

        public POS OfertaPOS()
        {
            return Pos;
        }

    }
}
