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
        //Fodboldklubben TEC
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1252);
            int antalBørneBilletter;
            int antalVoksenBilletter;
            int børneBilletPris = 30;
            int voksenBilletPris = 65;
            int rabat = 10;
            string titel = "FODBOLD KLUBBEN TEC";
            string medlemSvar;
            string seats = File.ReadAllText(@"C:\xampp\htdocs\github\Fodboldklubben-FC\Fodboldklubben FC\fodbold.txt");
            int seatsInt = Convert.ToInt32(seats);
            double totalSum;
            double euroKurs = 0.13;
            double euroSum;
            double rabatSum;

            //Ændre baggrundsfarve og tekstfarve
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            //Udskriver overskift/titel og ændre farverne igen
            Console.WriteLine(titel);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            //Udskriver maskinen's dato
            DateTime dateAndTime = DateTime.Now;
            Console.SetCursorPosition(110, 0);
            Console.WriteLine(dateAndTime.ToString("dd/MM/yyyy"));


            //Udskriver det antal pladser der står i tekstdokumentet "fodbold.txt"
            Console.SetCursorPosition(0, 2);
            System.Console.WriteLine("\nAntal ledige pladser: {0}", seatsInt);
            Console.WriteLine();

            //
            do
            {
                Console.Write("\nHvor mange børnebilletter vil du købe?: ");
                antalBørneBilletter = Convert.ToInt32(Console.ReadLine());

                if (antalBørneBilletter > 10)
                {
                    Console.WriteLine("\nDu kan ikke bestille mere end 10 børnebillet(ter)");
                    Console.WriteLine("");
                }
            } while (antalBørneBilletter > 10);

            Console.WriteLine("\nDu har valgt {0} børnebilletter", antalBørneBilletter);

            //
            do
            {
                Console.Write("\nHvor mange voksenbilletter vil du købe?: ");
                antalVoksenBilletter = Convert.ToInt32(Console.ReadLine());
                if (antalVoksenBilletter > 10)
                {
                    Console.WriteLine("\nDu kan ikke bestille mere end 10 voksenbilletter");
                    Console.WriteLine("");
                }
            } while (antalVoksenBilletter > 10);


            Console.WriteLine("\nDu har valgt {0} voksenbillet(ter)", antalVoksenBilletter);

            //
            seatsInt = seatsInt - (antalBørneBilletter + antalVoksenBilletter);
            seats = Convert.ToString(seatsInt);
            File.WriteAllText(@"C:\xampp\htdocs\github\Fodboldklubben-FC\Fodboldklubben FC\fodbold.txt", seats);


            //
            Console.Write("\nEr du klubmedlem? (ja/nej): ");
            medlemSvar = Console.ReadLine();

            //
            switch (medlemSvar.ToLower())
            {
                //
                case "ja":

                    Console.WriteLine("\nDu har bestilt et total af {0} billet(ter)\n", antalBørneBilletter + antalVoksenBilletter);
                    Console.WriteLine("Børnebilletter: {0}", antalBørneBilletter);
                    Console.WriteLine("Voksenbilletter: {0}", antalVoksenBilletter);

                    //
                    totalSum = ((antalBørneBilletter * børneBilletPris) + (antalVoksenBilletter * voksenBilletPris));
                    totalSum = totalSum - (totalSum * rabat / 100);

                    //
                    euroSum = totalSum * euroKurs;
                    euroSum = Math.Ceiling(euroSum);

                    //
                    rabatSum = (((antalBørneBilletter * børneBilletPris) + (antalVoksenBilletter * voksenBilletPris)) - totalSum);
                   
                    Console.WriteLine("\nMed klubmedlem rabat spare du {0} DKK", rabatSum);
                    Console.WriteLine("\nDen totale pris er {0} DKK/ \u20AC{1}", totalSum, euroSum);
                    break;

                //
                case "nej":
                    Console.WriteLine("\nDu har bestilt et total af {0} billet(ter)\n", antalBørneBilletter + antalVoksenBilletter);
                    Console.WriteLine("Børnebilletter: {0}", antalBørneBilletter);
                    Console.WriteLine("Voksenbilletter: {0}", antalVoksenBilletter);

                    //
                    totalSum = (antalBørneBilletter * børneBilletPris) + (antalVoksenBilletter * voksenBilletPris);

                    //
                    euroSum = totalSum * euroKurs;
                    euroSum = Math.Round(euroSum);

                    Console.WriteLine("\nDen totale pris er {0} DKK/ \u20AC{1}", totalSum, euroSum);
                    break;

                //
                default:
                    Console.WriteLine("{0} er ikke en korrekt mulighed", medlemSvar);
                    break;
            }
            Console.WriteLine("\nAntal ledige pladser: {0}", seatsInt);

            Console.ReadKey();
        }
    }
}
