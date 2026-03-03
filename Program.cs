using System;
using System.Collections.Generic;

namespace LABB_4_I_J
{
    //SPRINT 1: Egna typer (Ändrat till Stor bokstav i namnet)
    public enum Gender { Kvinna, Man, Ickebinär, Annan }

    public struct Hair
    {
        public string Color;
        public int Length;
    }

    class Program
    {
        //SPRINT 2
        static List<person> personLista = new List<person>();

        static void Main(string[] args)
        {
            // SPRINT 1: Testperson (Fixat årtal 200 -> 2000)
            person testPerson = new person();
            testPerson.FirstName = "Kalle";
            testPerson.LastName = "Test";
            testPerson.Birthday = new DateTime(2000, 01, 01);
            testPerson.PersonGender = Gender.Man;
            testPerson.PersonHair = new Hair { Color = "Svart", Length = 5 };

            Console.WriteLine("Sprint 1 - Testutskrift");
            Console.WriteLine(testPerson.ToString());

            bool koraProgram = true;
            while (koraProgram)
            {
                Console.WriteLine("\n--- Meny ---");
                Console.WriteLine("1. Lägg till person");
                Console.WriteLine("2. Visa lista");
                Console.WriteLine("3.Avsluta");
                Console.Write("Välj; ");

                string val = Console.ReadLine();

                switch (val)
                {
                    case "1":
                        AddPerson();
                        break;
                    case "2":
                        ListPersons();
                        break;
                    case "3":
                        Console.WriteLine("Avslutar programmet...");
                        koraProgram = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen (1-3).");
                        break;
                }
            }
        }

        static void AddPerson()
        {
            person p = new person();

            Console.Write("Förnamn: ");
            p.FirstName = Console.ReadLine();

            Console.Write("Efternamn: ");
            p.LastName = Console.ReadLine();

            while (true)
            {
                Console.Write("Födelsedag (ÅÅÅÅ-MM-DD): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime datum))
                {
                    p.Birthday = datum;
                    break;
                }
                Console.WriteLine("Fel format, försök igen.");
            }
            //Validering och inmatning av kön (Gender)
            while (true)
            {
                Console.WriteLine("Välj kön: 0=Kvinna, 1=Man, 2=IckeBinär, 3=Annan");
                Console.WriteLine("Val: ");
                if (int.TryParse(Console.ReadLine(), out int gVal) && Enum.IsDefined(typeof(Gender), gVal))
                {
                    p.PersonGender = (Gender)gVal;
                    break;
                }
                Console.WriteLine("Felaktigt val, ange en siffra mellan 0 och 3.");
            }

            Console.Write("Ögonfärg: ");
            p.EyeColor = Console.ReadLine();
                
            Hair h = new Hair();
            Console.Write("Hårfärg: ");
            h.Color = Console.ReadLine();

            while (true)
            {
                Console.Write("Hårlängd (siffra i cm): ");
                if (int.TryParse(Console.ReadLine(), out int langd))
                {
                    h.Length = langd;
                    break;
                }
                Console.WriteLine("Felaktig inmatning, ange ett heltal.");
            }

            p.PersonHair = h;
            personLista.Add(p);
            Console.WriteLine("Sparad!");
        }

        static void ListPersons()
        {
            Console.WriteLine("\n--- Alla i listan ---");
            if (personLista.Count == 0)
            {
                Console.WriteLine("Listan är tom.");
            }
            else
            {
                foreach (person p in personLista)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }
    }
}