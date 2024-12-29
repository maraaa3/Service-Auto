namespace DefaultNamespace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Program
{
    private static List<Utilizator> utilizatori = new List<Utilizator>();
    private static ILogger Logger = new ConsoleLogger();
    private static string filePath = "utilizatori.json";

    public static void Main(string[] args)
    {
        IncarcareUtilizatori();

        while (true)
        {
            Console.WriteLine("\nMeniu Principal:");
            Console.WriteLine("1. Logare");
            Console.WriteLine("2. Adaugare utilizator");
            Console.WriteLine("3. Iesire");
            Console.Write("Selectati o optiune: ");
            string optiune = Console.ReadLine();

            switch (optiune)
            {
                case "1":
                    Logare();
                    break;

                case "2":
                    AdaugaUtilizator();
                    SalvareUtilizatori();
                    break;

                case "3":
                    SalvareUtilizatori();
                    Console.WriteLine("Iesire program. La revedere!");
                    return;

                default:
                    Console.WriteLine("Optiune invalidă. Incercati din nou.");
                    break;
            }
        }
    }

    private static void Logare()
    {
        Console.Write("Introduceti emailul: ");
        string email = Console.ReadLine();

        Console.Write("Introduceti parola: ");
        string parola = Console.ReadLine();

        var utilizator = utilizatori.Find(u => u.Email == email && u.Parola == parola);

        if (utilizator != null)
        {
            Console.WriteLine($"Logare reusita! Bine ati revenit, {utilizator.Nume} {utilizator.Prenume}.");
            Logger.Log($"Utilizator logat: {utilizator.Nume} {utilizator.Prenume} ({utilizator.Email}).");
        }
        else
        {
            Console.WriteLine("Email sau parola incorecta. Incercati din nou.");
            Logger.Log($"Incercare de logare esuata pentru email: {email}.");
        }
    }

    private static void AdaugaUtilizator()
    {
        Console.WriteLine("\nAdaugare utilizator:");

        Console.Write("Introduceti tipul de utilizator (1. Administrator, 2. Mecanic): ");
        string tipUtilizator = Console.ReadLine();

        Console.Write("Introduceti codul unic: ");
        string codUnic = Console.ReadLine();

        Console.Write("Introduceti numele: ");
        string nume = Console.ReadLine();

        Console.Write("Introduceti prenumele: ");
        string prenume = Console.ReadLine();

        Console.Write("Introduceti emailul: ");
        string email = Console.ReadLine();

        Console.Write("Introduceti parola: ");
        string parola = Console.ReadLine();

        if (tipUtilizator == "1")
        {
            utilizatori.Add(new Administrator(codUnic, nume, prenume, email, parola));
            Console.WriteLine("Administrator adaugat cu succes!");
        }
        else if (tipUtilizator == "2")
        {
            utilizatori.Add(new Mecanic(codUnic, nume, prenume, email, parola));
            Console.WriteLine("Mecanic adaugat cu succes!");
        }
        else
        {
            Console.WriteLine("Tip de utilizator invalid. Incercati din nou.");
        }

        Logger.Log($"Utilizator adaugat: {nume} {prenume} ({email}).");
    }

    private static void SalvareUtilizatori()
    {
        string json = JsonSerializer.Serialize(utilizatori);
        File.WriteAllText(filePath, json);
        Logger.Log("Utilizatorii au fost salvati în fisier.");
    }

    private static void IncarcareUtilizatori()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            utilizatori = JsonSerializer.Deserialize<List<Utilizator>>(json) ?? new List<Utilizator>();
            Logger.Log("Utilizatorii au fost incarcati din fisier.");
        }
        else
        {
            Logger.Log("Fisierul de utilizatori nu exista. Se va crea unul nou.");
            utilizatori = new List<Utilizator>();
        }
    }
}
