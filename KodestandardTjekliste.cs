// KodestandardTjekliste.cs
//
// ØVELSESFIL — Modul 3, Lektion 5.
// Denne fil "virker" (den kompilerer og giver korrekte resultater), men
// overtræder Microsofts C#-kodestandard på en lang række punkter.
//
// DIN OPGAVE: Find og noter, hvilke KATEGORIER af fejl du kan se i filen
// (ikke bare hvert enkelt sted — men hvilken type problem det er), og ret
// derefter filen, så den fuldt ud overholder kodestandarden fra materiale.md.
//
// Underviserens facitliste findes i KodestandardTjekliste-FACIT.md i denne
// mappe — kig IKKE i den, før du selv har lavet øvelsen færdig.

//Remove unused usings (comment out)
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

class ProductCalculator //Klasser skal være i PascalCase; productCalculator -> ProductCalculator 
{
    const int MaxQuantity = 100; //Konstanter skal være i Pascal case maxQuantity -> MaxQuantity 

    static void Main(string[] args)
    {
        List<string> varer = new List<string>();
        List<decimal> antal = new List<decimal>();
        List<decimal> pris = new List<decimal>();
        decimal subtotal = 0;
        do
        {
            //Brugerinput print instruktion. 
            Console.WriteLine("Indtast {Varenavn} {antal} {pris pr. enhed}");
            string input = Console.ReadLine();
            string[] inputTokens = input.Split(' ');
            //Valider bruger input
            if (inputTokens.Length != 3)
            {
                Console.WriteLine("Fejl. Forkert antal input! prøv igen!");
                continue;
            }
            decimal inputAntal;
            decimal inputPris;
            if (!Decimal.TryParse(inputTokens[1], out inputAntal))
            {
                Console.WriteLine("Fejl: Antal skal være et tal! Prøv igen!");
                continue;
            }
            if (!Decimal.TryParse(inputTokens[2], out inputPris))
            {
                Console.WriteLine("Fejl: Pris skal være et tal! Prøv igen!");
                continue;
            }
            varer.Add(inputTokens[0]);
            antal.Add(inputAntal);
            pris.Add(inputPris);
            subtotal += inputPris;

            Console.WriteLine("vil du registrere endnu en vare? (j/n)");
            char tast = '0';
            while (true)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case 'j':
                        tast = 'j';
                        break;
                    case 'n':
                        tast = 'n';
                        break;
                    default:
                        break;
                }
                if (tast == 'j' || tast == 'n') break;
            }
            if (tast == 'n') break;

        } while (true);

        Console.Clear();
        Console.WriteLine("REGNING: ");
        for (int i = 0; i < varer.Count; i++)
        {
            Console.WriteLine($"\t{varer[i]}\t\t{antal[i]} á {pris[i]}kr=\t{antal[i] * pris[i]}kr");
        }
        Console.WriteLine();
        if (subtotal > 500)
        {
            Console.WriteLine($"SUBTOTAL: {subtotal}");
            decimal rabat = Rabat(subtotal, 15m);
            decimal nyTotal = subtotal - rabat;
            Console.WriteLine($"Købt for over 500kr giver 15% rabat: {rabat} kr");
            Console.WriteLine($"TOTAL AT BETALE: {nyTotal}kr.");
            
        } else
        {
            Console.WriteLine($"TOTAL AT BETALE: {subtotal}kr.");
        }
        Console.ReadKey();
    }

    static decimal Rabat(decimal beløb, decimal procent)
    {
        return beløb * (procent/100m); 
    }
}

