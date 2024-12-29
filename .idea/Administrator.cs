namespace DefaultNamespace;

public class Administrator : Utilizator
{
    private List<CerereRezolvare> _cereriRezolvare;
    private List<CererePieseAuto> _comenziPiese;

    public Administrator(string codUnic, string nume, string prenume, string email, string parola)
        : base(codUnic, nume, prenume, email, parola) { 
        _cereriRezolvare = new List<CerereRezolvare>();
        _comenziPiese = new List<CererePieseAuto>();
}

public override void Meniu()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("Meniu Administrator:");
            Console.WriteLine("1. Vizualizare cereri rezolvare probleme.");
            Console.WriteLine("2. Vizualizare comenzi piese auto.");
            Console.WriteLine("3. Preluare si finalizare comenzi piese auto.");
            Console.WriteLine("4. Adaugare cerere rezolvare probleme.");
            Console.WriteLine("5. Deconectare.");
            Console.Write("Alege o optiune: ");

            var optiune = Console.ReadLine();
            switch (optiune)
            {
                case "1":
                    VizualizeazaCereriRezolvare();
                    break;
                case "2":
                    VizualizeazaComenziPiese();
                    break;
                case "3":
                    PreluareSiFinalizareComenziPiese();
                    break;
                case "4":
                    AdaugaCerereRezolvare();
                    break;
                case "5":
                    Console.WriteLine("Te-ai deconectat. Aplicatia se va inchide.");
                    Environment.Exit(0); // Iesim din aplicatie
                    break;
                default:
                    Console.WriteLine("Optiune invalida. Încearca din nou.");
                    break;
            }
        }
    }

    private void VizualizeazaCereriRezolvare()
    {
        if (_cereriRezolvare.Count == 0)
        {
            Console.WriteLine("Nu exista cereri de rezolvare.");
        }
        else
        {
            foreach (var cerere in _cereriRezolvare)
            {
                Console.WriteLine(cerere.ToString());
            }
        }
    }

    private void VizualizeazaComenziPiese()
    {
        if (_comenziPiese.Count == 0)
        {
            Console.WriteLine("Nu exista comenzi pentru piese.");
        }
        else
        {
            foreach (var comanda in _comenziPiese)
            {
                Console.WriteLine(comanda.ToString());
            }
        }
    }

    private void PreluareSiFinalizareComenziPiese()
    {
        if (_comenziPiese.Count == 0)
        {
            Console.WriteLine("Nu sunt comenzi de piese disponibile pentru preluare.");
            return;
        }

        Console.WriteLine("Alege comanda de piese pentru preluare:");
        for (int i = 0; i < _comenziPiese.Count; i++)
        {
            var cerere = _comenziPiese[i];
            Console.WriteLine($"{i + 1}. {cerere.ToString()}");
        }

        int optiuneComanda = int.Parse(Console.ReadLine()) - 1;
        if (optiuneComanda < 0 || optiuneComanda >= _comenziPiese.Count)
        {
            Console.WriteLine("Optiune invalida.");
            return;
        }

        var comanda = _comenziPiese[optiuneComanda];
        if (comanda.Status == StatusPiese.InAsteptare)
        {
            comanda.FinalizeazaCerere();
        }
        else
        {
            Console.WriteLine("Comanda nu poate fi finalizata, nu este in starea corecta.");
        }
    }

    private void AdaugaCerereRezolvare()
    {
        Console.Write("Introduceti codul unic pentru cererea de rezolvare: ");
        string codUnic = Console.ReadLine();

        Console.Write("Introduceti numele clientului: ");
        string numeClient = Console.ReadLine();

        Console.Write("Introduceti numarul masinii: ");
        string numarMasina = Console.ReadLine();

        // Validare numar masina
        if (!long.TryParse(numarMasina, out _))
        {
            Console.WriteLine("Numar masina invalid.");
            return;
        }

        Console.Write("Introduceti descrierea problemei: ");
        string descriereProblema = Console.ReadLine();

        var cerereRezolvare = new CerereRezolvare(codUnic, numeClient, numarMasina, descriereProblema);
        _cereriRezolvare.Add(cerereRezolvare);

        Console.WriteLine($"Cererea de rezolvare {codUnic} a fost adaugata cu succes.");
    }
}