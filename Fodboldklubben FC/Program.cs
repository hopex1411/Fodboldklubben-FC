using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fodboldklubben_FC
{
    class Program
    {
        //Ada - D82
        //20210911
        //Obligatorisk Opgave - Fodboldklubben TEC
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1252);
            string titel = "FODBOLD KLUBBEN TEC";
            string medlemSvar;
            string seats = File.ReadAllText(@"C:\xampp\htdocs\github\Fodboldklubben-FC\Fodboldklubben FC\fodbold.txt");
            int seatsInt = Convert.ToInt32(seats);
            int antalBørneBilletter;
            int antalVoksenBilletter;
            int børneBilletPris = 30;
            int voksenBilletPris = 65;
            int rabat = 10;
            double totalSum;
            double euroKurs = 0.13;
            double euroSum;
            double rabatSum;

            Console.SetWindowSize(121, 35);

            //Ændre baggrundsfarve og tekstfarve
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            //Udskriver overskift/titel og ændre farverne igen
            Console.SetCursorPosition(55, 0);
            Console.WriteLine(titel);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            //Udskriver maskinen's dato
            DateTime dateAndTime = DateTime.Now;
            Console.SetCursorPosition(110, 0);
            Console.WriteLine(dateAndTime.ToString("dd/MM/yyyy"));


            //Udskriver det antal pladser der står i tekstdokumentet "fodbold.txt"
            Console.WriteLine("Antal ledige pladser: {0}", seatsInt);

            do {
                Console.Write("Indtast hvor mange børnebilletter vil du købe?: ");
                antalBørneBilletter = Convert.ToInt32(Console.ReadLine());

                //Tjekker om antallet billetter er større end 10
                if (antalBørneBilletter > 10)
                {
                    Console.WriteLine("Du kan ikke bestille mere end 10 børnebillet(ter)");
                    Console.WriteLine("");
                }
            } while (antalBørneBilletter > 10);

            Console.WriteLine("Du har valgt {0} børnebillet(ter)", antalBørneBilletter);

            do
            {
                Console.Write("\nIndtast hvor mange voksenbilletter vil du købe?: ");
                antalVoksenBilletter = Convert.ToInt32(Console.ReadLine());

                //Tjekker om antallet billetter er større end 10
                if (antalVoksenBilletter > 10)
                {
                    Console.WriteLine("Du kan ikke bestille mere end 10 voksenbilletter");
                    Console.WriteLine("");
                }
            } while (antalVoksenBilletter > 10);

            Console.WriteLine("Du har valgt {0} voksenbillet(ter)", antalVoksenBilletter);

            //Regner antallet af valgte billetter og trækker dem fra antal pladser og opdatere dokumentet
            seatsInt = seatsInt - (antalBørneBilletter + antalVoksenBilletter);
            seats = Convert.ToString(seatsInt);
            File.WriteAllText(@"C:\xampp\htdocs\github\Fodboldklubben-FC\Fodboldklubben FC\fodbold.txt", seats);

            Console.Write("\nEr du klubmedlem? (ja/nej): ");
            medlemSvar = Console.ReadLine();

            //Tjekker om brugeren er klubmedlem
            switch (medlemSvar.ToLower())
            {
                //Er brugeren klubmedlem får de den procent rabat der er deklareret i toppen
                case "ja":

                    Console.WriteLine("\nDu har bestilt et total af {0} billet(ter)\n", antalBørneBilletter + antalVoksenBilletter);
                    Console.WriteLine("Børnebilletter: {0}", antalBørneBilletter);
                    Console.WriteLine("Voksenbilletter: {0}", antalVoksenBilletter);

                    //Udregner rabat med at priserne af billetterne lagt sammen,
                    //ganget med rabatprocent divideret med 100 minus priserne af billetterne lagt sammen
                    totalSum = ((antalBørneBilletter * børneBilletPris) + (antalVoksenBilletter * voksenBilletPris));
                    totalSum = totalSum - (totalSum * rabat / 100);

                    //Konvetere prisen til EUR ved at gange priserne af billtterne lagt sammen med den deklareret kurs
                    euroSum = totalSum * euroKurs;
                    euroSum = Math.Ceiling(euroSum);

                    //Udksriver det man spare i rabat
                    rabatSum = (((antalBørneBilletter * børneBilletPris) + (antalVoksenBilletter * voksenBilletPris)) - totalSum);

                    Console.WriteLine("\nMed klubmedlem rabat spare du {0} DKK", rabatSum);
                    Console.WriteLine("\nDen totale pris er {0} DKK/ \u20AC{1}", totalSum, euroSum);
                    break;

                //Er brugeren ikke klubmedlem får de bare den endelige pris udskrevet
                case "nej":
                    Console.WriteLine("\nDu har bestilt et total af {0} billet(ter)\n", antalBørneBilletter + antalVoksenBilletter);
                    Console.WriteLine("Børnebilletter: {0}", antalBørneBilletter);
                    Console.WriteLine("Voksenbilletter: {0}", antalVoksenBilletter);

                    //Udregner total pris af billetter
                    totalSum = (antalBørneBilletter * børneBilletPris) + (antalVoksenBilletter * voksenBilletPris);

                    ////Konvetere prisen til EUR ved at gange priserne af billtterne lagt sammen med den deklareret kurs
                    euroSum = totalSum * euroKurs;
                    euroSum = Math.Round(euroSum);

                    Console.WriteLine("\nDen totale pris er {0} DKK/ \u20AC{1}", totalSum, euroSum);
                    break;

                //Skriver man noget andet en ja el. nej, udskriver den nedstående
                default:
                    Console.WriteLine("{0} er ikke en korrekt mulighed", medlemSvar);
                    break;
            }
            //Udskriver det antal pladser der står i tekstdokumentet "fodbold.txt"
            Console.SetCursorPosition(52, 2);
            Console.WriteLine("Antal ledige pladser: {0}", seatsInt);
            Console.ReadKey();
        }
    }
}
