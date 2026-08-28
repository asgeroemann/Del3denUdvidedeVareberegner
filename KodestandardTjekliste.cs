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
        Console.WriteLine("Indtast antal varer:");
        string quantityInput = Console.ReadLine(); //Ungarsk notation; strQuantity-quantity. Lokal variabel.
        int quantity = Convert.ToInt32(quantityInput); // Men nu får vi så 2 variabler med samme navn
                                                      // hvor den ungarsk notation før differentierde dem
                                                      //strQuantity -> quantityInput

        Console.WriteLine("Indtast pris pr. vare:");
        string priceInput = Console.ReadLine();           //Ungarsk notation igen. strPrice->priceInput
        double price = Convert.ToDouble(priceInput);      //dPrice->price, for meget inrykning

        // Sætter x til antal gange pris
        double samletPris = quantity * price;           //Ikke meningsfuldt navn. x->samletPris

        if (samletPris > 500)
        {
        double rabat = samletPris * 0.15;               //Ikke meningsfuldt navn y->rabat
        double prisEfterRabat = samletPris - rabat;                  //z->prisEfterRabat
            Console.WriteLine("Rabat: " + rabat);
            Console.WriteLine("Total: " + prisEfterRabat);
        }
        else {
            Console.WriteLine("Total: " + samletPris);
        }

        string message = CalculateStatus(quantity); //Skriv typen tydeligt når typen er skjult
        Console.WriteLine(message);
        
    }

    static string CalculateStatus(int quantity) //Lokal variabel skal være med camelCase Quantity->quantity
                                                //Metode-navne skal være i PascalCase. calculate_Status->CalculateStatus
                                                //Man kunne også sige navnet ikke er særligt meningsfuldt (hvilken status?)
    {
        if (quantity > 50)
        {
            return "Stor ordre";
        }
        return "Almindelig ordre";
    }
}

