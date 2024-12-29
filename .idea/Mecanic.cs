namespace DefaultNamespace;

public class Mecanic : Utilizator
{
    private List<CerereRezolvare> _cereriRezolvare;
    public Mecanic(string codUnic, string nume, string prenume, string email, string parola)
        : base(codUnic, nume, prenume, email, parola) {
    _cereriRezolvare = new List<CerereRezolvare>();
 }

public override void Meniu()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("Meniu Mecanic:");
            Console.WriteLine("1. Preluare cerere rezolvare.");
            Console.WriteLine("2. Investigare problema.");
            Console.WriteLine("3. Creare cerere piese auto.");
            Console.WriteLine("4. Rezolvare problema masina.");
            Console.WriteLine("5. Deconectare.");
            Console.Write("Alege o optiune: ");

            var optiune = Console.ReadLine();
            switch (optiune)
            {
                case "1":
                    PreluareCerereRezolvare();
                    break;
                case "2":
                    InvestigareProblema();
                    break;
                case "3":
                    CreareCererePieseAuto();
                    break;
                case "4":
                    RezolvareProblemaMasina();
                    break;
                case "5":
                    Console.WriteLine("Te-ai deconectat. Aplicatia se va inchide.");
                    Environment.Exit(0); // Iesim din aplicatie
                    break;
                default:
                    Console.WriteLine("Optiune invalida. Incearca din nou.");
                    break;
            }
        }
    }

    private void PreluareCerereRezolvare()
    {
        if (_cereriRezolvare.Count == 0)
        {
            Console.WriteLine("Nu exista cereri de rezolvare.");
            return;
        }

        Console.WriteLine("Alege cererea de rezolvare de preluat:");
        for (int i = 0; i < _cereriRezolvare.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_cereriRezolvare[i].ToString()}");
        }

        int optiune = int.Parse(Console.ReadLine()) - 1;
        if (optiune < 0 || optiune >= _cereriRezolvare.Count)
        {
            Console.WriteLine("Optiune invalida.");
            return;
        }

        var cerere = _cereriRezolvare[optiune];
        cerere.AsociazaMecanic($"{Nume} {Prenume}");
    }

    private void InvestigareProblema()
    {
        Console.WriteLine("Alege cererea de rezolvare de investigat:");
        for (int i = 0; i < _cereriRezolvare.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_cereriRezolvare[i].ToString()}");
        }

        int optiune = int.Parse(Console.ReadLine()) - 1;
        if (optiune < 0 || optiune >= _cereriRezolvare.Count)
        {
            Console.WriteLine("Optiune invalida.");
            return;
        }

        var cerere = _cereriRezolvare[optiune];
        Console.WriteLine($"Investigand cererea: {cerere.ToString()}");
        // Aici poți adăuga logica pentru investigarea cererii.
    }

    private void CreareCererePieseAuto()
    {
        Console.Write("Introduceti AVB pentru piesele auto: ");
        int avb = int.Parse(Console.ReadLine());

        Console.Write("Introduceti numele utilizatorului ce a lansat cererea: ");
        string numeUtilizator = Console.ReadLine();

        Console.Write("Introduceti detalii pentru piesele auto: ");
        string detalii = Console.ReadLine();

        var cererePieseAuto = new CererePieseAuto(avb, numeUtilizator, detalii);
        Console.WriteLine($"Cererea de piese auto {avb} a fost adaugata.");
        // Poți adăuga logica pentru a asocia cererea de piese la o cerere de rezolvare.
    }

    private void RezolvareProblemaMasina()
    {
        Console.WriteLine("Alege cererea de rezolvare pentru care doresti sa rezolvi problema:");
        for (int i = 0; i < _cereriRezolvare.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_cereriRezolvare[i].ToString()}");
        }

        int optiune = int.Parse(Console.ReadLine()) - 1;
        if (optiune < 0 || optiune >= _cereriRezolvare.Count)
        {
            Console.WriteLine("Optiune invalida.");
            return;
        }

        var cerere = _cereriRezolvare[optiune];
        Console.Write("Problema masinii poate fi rezolvata cu piese (da/nu)? ");
        string raspuns = Console.ReadLine().ToLower();

        if (raspuns == "da")
        {
            cerere.RezolvaProblema(true);
        }
        else if (raspuns == "nu")
        {
            cerere.RezolvaProblema(false);
        }
        else
        {
            Console.WriteLine("Raspuns invalid.");
        }
    }
}