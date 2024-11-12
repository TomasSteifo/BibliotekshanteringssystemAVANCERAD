using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;


namespace BibliotekshanteringssystemAVANCERAD
{
    // Program class: Hanterar användarens interaktion med menysystemet.
    public class Program
    {
        static void Main(string[] args)
        {
            Bibliotek bibliotek = LibraryDataHandler.LaddaDataFrånFil();
            bool körProgram = true;

            while (körProgram)
            {
                Console.WriteLine("\nBibliotekshanteringssystem");
                Console.WriteLine("1. Lägg till ny bok");
                Console.WriteLine("2. Lägg till ny författare");
                Console.WriteLine("3. Uppdatera bokdetaljer");
                Console.WriteLine("4. Uppdatera författardetaljer");
                Console.WriteLine("5. Ta bort bok");
                Console.WriteLine("6. Ta bort författare");
                Console.WriteLine("7. Lista alla böcker");
                Console.WriteLine("8. Lista alla författare");
                Console.WriteLine("9. Sök och filtrera böcker");
                Console.WriteLine("10. Avsluta och spara data");
                Console.Write("Välj ett alternativ: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        bibliotek.LaggTillBok();
                        break;
                    case "2":
                        bibliotek.LaggTillForfattare();
                        break;
                    case "3":
                        bibliotek.UppdateraBok();
                        break;
                    case "4":
                        bibliotek.UppdateraForfattare();
                        break;
                    case "5":
                        bibliotek.TaBortBok();
                        break;
                    case "6":
                        bibliotek.TaBortForfattare();
                        break;
                    case "7":
                        bibliotek.ListaBocker();
                        break;
                    case "8":
                        bibliotek.ListaForfattare();
                        break;
                    case "9":
                        bibliotek.SokOchFiltreraBocker();
                        break;
                    case "10":
                        LibraryDataHandler.SparaDataTillFil(bibliotek);
                        körProgram = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }
        }
    }
}
