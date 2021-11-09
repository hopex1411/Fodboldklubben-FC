using System;
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
            int antalBørneBilletter=0;
            int antalVoksenBilletter=0;
            int børneBilletPris=30;
            int voksenBilletPris=65;
            double totalSum;
            int rabat = 10;
            string medlemJa = "ja";
            string medlemNej = "nej";
            string medlemSvar = "";


            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("FODBOLD KLUBBEN TEC");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();

            DateTime dateAndTime = DateTime.Now;
            Console.SetCursorPosition(110, 0);
            Console.WriteLine(dateAndTime.ToString("dd/MM/yyyy"));

            do
            {
                Console.Write("Hvor mange børnebilletter vil du købe?: ");
                antalBørneBilletter = Convert.ToInt32(Console.ReadLine());

                if (antalBørneBilletter > 10)
                {
                    Console.WriteLine("Du kan ikke bestille mere end 10 børnebilletter.");
                    Console.WriteLine("");
                }
            } while (antalBørneBilletter>10);

            Console.WriteLine("Du har valgt {0} børnebilletter", antalBørneBilletter);

            Console.Write("Hvor mange voksenbilletter vil du købe?: ");
            antalVoksenBilletter = Convert.ToInt32(Console.ReadLine());


            //Skal loopes hvis antal er over 10
            if (antalVoksenBilletter > 10)
            {
                Console.WriteLine("Du kan ikke bestille mere end 10 voksenbilletter.");
            }

            Console.WriteLine("Du har valgt {0} voksenbilletter", antalVoksenBilletter);

            Console.Write("Er du klubmedlem? (ja/nej): ");
            medlemSvar = Console.ReadLine();

            switch (medlemSvar.ToLower())
            {
                case "ja":
                    totalSum = ((antalBørneBilletter * børneBilletPris) + (antalVoksenBilletter * voksenBilletPris));

                    totalSum = totalSum - (totalSum * rabat / 100);

                    Console.Write("Den totale sum er: " + totalSum);
                    break;

                case "nej":
                    totalSum = (antalBørneBilletter * børneBilletPris) + (antalVoksenBilletter*voksenBilletPris);
                    Console.Write("Den totale sum er: " + totalSum);

                    break;
            }


            Console.ReadKey();
        }
    }
}
