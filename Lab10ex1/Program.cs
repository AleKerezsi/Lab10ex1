using System;
using Lab10ex1.Extensii;

namespace Lab10ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Scrieti un program care va modela operatiunile unei casa de marcat.
            Casa de marcat
            O casa de marcat va avea o metoda prin care va scana un produs, va oferi metode de plata cash sau prin
            intermediul unui POS.
            • In cazul platii cash, casa de marcat
            1. va deschide un seif
            2. va introduce suma in seif
            3. va inchide seif-ul
            4. Va elibera chitanta
            Aceasta functionalitate va fi modelata printr-o metoda care va primi un singur parametru, suma
            de plata. La fiecare dintre operatiunile de mai sus, un mesaj corespunzator va fi afisat pe ecran
            • In cazul platii cu cardul, casa de marcat va pune la dispozitia clientului un POS, printr-o metoda care
            va oferi la cerere un POS
            POS-ul
            POS-ul va accepta atat plata contactless cat si plata contact-full. Cele doua modalitati de plata vor fi
            modelate prin intermediul a doua metode, ce vor primi doi parametri: suma si dispozitivul prin care se
            va efectua plata „ascuns” sub o interfata specifica fiecarui mod de plata.
            Pentru plata prin intermediul POS-ului, clientul va putea folosi atat
             carduri clasice – suporta doar plati contactfull
             carduri contactless - suporta atat plati contact-full cat si plati contactless
             telefoane mobile contactless - suporta doar plati contactless
            Descrierea interfetelor
            Plata contact-full implica urmatoarele operatiuni:
             IntroduCard
             EfectueazaPlata
             ExtrageCard
            Plata contactless implica urmatoarele operatiuni:
             ApropieCard
             EfectueazaPlata
            Instantiati casa, carduri, telefoane, efectuati plati.*/


            CasaDeMarcat casa = new CasaDeMarcat();

            var cardClasic = new CardClasic(500.0);
            var cardContactless = new CardContactless(420.0);
            var telefonContactless = new TelefonContactless(715.0);

            var ciocolata1 = new Produs() { Nume = "Milka", Descriere = "ciocolata cu alune", Pret = 15.0 };
            var ciocolata2 = new Produs() { Nume = "Africana", Descriere = "ciocolata cu lapte", Pret = 15.0 };
            var ciocolata3 = new Produs() { Nume = "Primola", Descriere = "ciocolata cu capsuni", Pret = 15.0 };
            var paine = new Produs() { Nume = "Velpitar", Descriere = "paine cu seminte", Pret = 35.0 };
            var lapte = new Produs() { Nume = "Zuzu", Descriere = "lapte 1.5%", Pret = 38.0 };
            var chips = new Produs() { Nume = "Lays", Descriere = "chipsuri cu sare", Pret = 22.0 };

            PlataCash(casa, ciocolata1, 6.0);
            PlataCash(casa, ciocolata2, 15.0);
            PlataCash(casa, ciocolata3, 20.0);

            PlataCardContactfull(casa, cardClasic,paine, 35.0);

            PlataCardContactless(casa, cardContactless,lapte, 38.0);

            PlataTelefonContactless(casa, telefonContactless,chips, 22.0);


        }

        public static void PlataCash(CasaDeMarcat casa, Produs produs, double bani) 
        {
            casa.ScanareProdus(produs);
            var successPlata1 = casa.Plateste(bani);
            if (successPlata1.Item1) casa.ElibereazaBonFiscal(produs);

            Console.WriteLine();
        }

        public static void PlataCardContactfull(CasaDeMarcat casa, IPlataContactFull cardClasic, Produs produs, double bani) 
        {
            casa.ScanareProdus(produs);

            var pos1 = casa.OfertaPOS();

            pos1.IntroduCard(cardClasic);
            var success = pos1.Plateste(bani, cardClasic);
            if (success)
            {
                pos1.ElibereazaChitanta(produs);
                casa.ElibereazaBonFiscal(produs);
            }
            pos1.ExtrageCard();


            Console.WriteLine();

        }

        public static void PlataCardContactless(CasaDeMarcat casa, IPlataContactless cardContactless, Produs produs, double bani) 
        {
            casa.ScanareProdus(produs);
            var pos2 = casa.OfertaPOS();
            var success = pos2.Plateste(bani, cardContactless);
            if (success)
            {
                pos2.ElibereazaChitanta(produs);
                casa.ElibereazaBonFiscal(produs);
            }

            Console.WriteLine();
        }

        public static void PlataTelefonContactless(CasaDeMarcat casa, IPlataContactless telefonContactless, Produs produs, double bani) 
        {
            casa.ScanareProdus(produs);
            var pos3 = casa.OfertaPOS();
            var success = pos3.Plateste(bani, telefonContactless);
            if (success)
            {
                pos3.ElibereazaChitanta(produs);
                casa.ElibereazaBonFiscal(produs);
            }

            Console.WriteLine();
        }

    }
}
