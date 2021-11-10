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
            string path = @"C:\xampp\htdocs\github\Fodboldklubben-FC\Fodboldklubben FC\fodbold.txt";
            double totalSum;
            double euroKurs = 0.13;
            double euroSum;
            double rabatSum;

           //
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(titel);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            DateTime dateAndTime = DateTime.Now;
            Console.SetCursorPosition(110, 0);
            Console.WriteLine(dateAndTime.ToString("dd/MM/yyyy"));

            string[] readText = File.ReadAllLines(path);
            Console.SetCursorPosition(0, 2);
            foreach (string antalPladser in readText)
            {
                Console.WriteLine("Der er {0} ledige pladser", antalPladser);
            }
            

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

            Console.Write("\nHvor mange voksenbilletter vil du købe?: ");
            antalVoksenBilletter = Convert.ToInt32(Console.ReadLine());


            do
            {
                if (antalVoksenBilletter > 10)
                {
                    Console.WriteLine("\nDu kan ikke bestille mere end 10 voksenbilletter");
                }
            } while (antalVoksenBilletter > 10);


            Console.WriteLine("\nDu har valgt {0} voksenbillet(ter)", antalVoksenBilletter);



            Console.Write("\nEr du klubmedlem? (ja/nej): ");
            medlemSvar = Console.ReadLine();

            switch (medlemSvar.ToLower())
            {
                case "ja":

                    Console.WriteLine("\nDu har bestilt et total af {0} billet(ter)\n", antalBørneBilletter + antalVoksenBilletter);
                    Console.WriteLine("Børnebilletter: {0}", antalBørneBilletter);
                    Console.WriteLine("Voksenbilletter: {0}", antalVoksenBilletter);

                    totalSum = ((antalBørneBilletter * børneBilletPris) + (antalVoksenBilletter * voksenBilletPris));
                    totalSum = totalSum - (totalSum * rabat / 100);

                    euroSum = totalSum * euroKurs;
                    euroSum = Math.Ceiling(euroSum);

                    rabatSum = (((antalBørneBilletter * børneBilletPris) + (antalVoksenBilletter * voksenBilletPris)) - totalSum);
                    Console.WriteLine("\nMed klubmedlem rabat spare du {0} DKK", rabatSum);
                    Console.WriteLine("\nDen totale pris er {0} DKK/ \u20AC{1:N2}", totalSum, euroSum);
                    break;

                case "nej":

                    totalSum = (antalBørneBilletter * børneBilletPris) + (antalVoksenBilletter * voksenBilletPris);

                    euroSum = totalSum * euroKurs;
                    euroSum = Math.Round(euroSum);

                    Console.WriteLine("\nDen totale pris er {0} DKK/ \u20AC{1}", totalSum, euroSum);
                    break;

                default:
                    Console.WriteLine("{0} er ikke en korrekt mulighed", medlemSvar);
                    break;
            }



            Console.ReadKey();
        }
    }
}
