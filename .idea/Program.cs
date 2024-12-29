namespace DefaultNamespace;
using System;
using System.Collections.Generic;

    public class Program
    {
        private static List<Utilizator> utilizatori = new List<Utilizator>();

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Meniu Principal:");
                Console.WriteLine("1. Logare");
                Console.WriteLine("2. Adaugare utilizator");
                Console.WriteLine("3. Iesire");
                Console.Write("Selectati o optiune: ");
                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        Console.WriteLine("Logare selectată. (Logica va fi adăugată ulterior)");
                        break;

                    case "2":
                        AdaugaUtilizator();
                        break;

                    case "3":
                        Console.WriteLine("Ieșire program. La revedere!");
                        return;

                    default:
                        Console.WriteLine("Opțiune invalidă. Încercați din nou.");
                        break;
                }
            }
        }

        private static void AdaugaUtilizator()
        {
            Console.WriteLine("Adăugare utilizator:");

            Console.Write("Introduceți tipul de utilizator (1. Administrator, 2. Mecanic): ");
            string tipUtilizator = Console.ReadLine();

            Console.Write("Introduceți codul unic: ");
            string codUnic = Console.ReadLine();

            Console.Write("Introduceți numele: ");
            string nume = Console.ReadLine();

            Console.Write("Introduceți prenumele: ");
            string prenume = Console.ReadLine();

            Console.Write("Introduceți emailul: ");
            string email = Console.ReadLine();

            Console.Write("Introduceți parola: ");
            string parola = Console.ReadLine();

            if (tipUtilizator == "1")
            {
                utilizatori.Add(new Administrator(codUnic, nume, prenume, email, parola));
                Console.WriteLine("Administrator adăugat cu succes!");
            }
            else if (tipUtilizator == "2")
            {
                utilizatori.Add(new Mecanic(codUnic, nume, prenume, email, parola));
                Console.WriteLine("Mecanic adăugat cu succes!");
            }
            else
            {
                Console.WriteLine("Tip de utilizator invalid. Încercați din nou.");
            }
        }
    }
    