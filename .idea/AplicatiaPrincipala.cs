namespace DefaultNamespace;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
    public class AplicatiaPrincipala : IAplicatiaPrincipala
    {
        private readonly ILogger<AplicatiaPrincipala> _logger;

        // Lista de utilizatori
        static List<Utilizator> utilizatori = new List<Utilizator>();
        static string filePath = "utilizatori.json";  // Calea fisierului cu utilizatori

        // Lista de cereri
        static List<CerereRezolvare> cereriRezolvare = new List<CerereRezolvare>();
        static List<CererePieseAuto> cereriPieseAuto = new List<CererePieseAuto>();

        public AplicatiaPrincipala(ILogger<AplicatiaPrincipala> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            // incarcarea utilizatorilor din fisier
            IncarcareUtilizatori();
			IncarcareCereriRezolvare();
            IncarcareCereriPieseAuto();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\nMeniu Principal:");
                Console.WriteLine("1. Logare");
                Console.WriteLine("2. Adauga utilizator");
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
                        break;

                    case "3":
                        SalvareUtilizatori();
                        SalvareCereriRezolvare();
                        SalvareCereriPieseAuto();
                        _logger.LogInformation("Iesire program. La revedere!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Optiune invalida. Incercati din nou.");
                        break;
                }
            }
        }

        // Logarea unui utilizator
        private void Logare()
        {
            Console.Write("Introduceti emailul: ");
            string email = Console.ReadLine();

            Console.Write("Introduceti parola: ");
            string parola = Console.ReadLine();

            var utilizator = utilizatori.Find(u => u.Email == email && u.Parola == parola);

            if (utilizator != null)
            {
                
                _logger.LogInformation($"Logare reusita! Bine ati revenit, {utilizator.Nume} {utilizator.Prenume}.");
                
                // Meniu diferit pentru Administrator și Mecanic
                if (utilizator is Administrator administrator)
                {
                    administrator.SetLoggerAfterDeserialization(_logger);
                    MeniuAdministrator(administrator);
                }
                else if (utilizator is Mecanic mecanic)
                {
                    mecanic.SetLoggerAfterDeserialization(_logger);
                    MeniuMecanic(mecanic);
                }
            }
            else
            {
                
                _logger.LogError("Email sau parola incorecta. Incercati din nou.");
            }
        }

        // Meniul pentru Administrator
        private void MeniuAdministrator(Administrator admin)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMeniu Administrator:");
                Console.WriteLine("1. Vizualizeaza cereri rezolvare");
                Console.WriteLine("2. Vizualizeaza cereri piese auto");
                Console.WriteLine("3. Preia comanda piese auto");
                Console.WriteLine("4. Finalizează Comanda de Piese Auto");
                Console.WriteLine("5. Adauga cerere rezolvare");
                Console.WriteLine("6. Iesire");
                Console.Write("Selectati o optiune: ");
                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        admin.VizualizeazaCereri(cereriRezolvare);
                        break;

                    case "2":
                        admin.VizualizeazaComandaPiese(cereriPieseAuto);
                        break;

                    case "3":
                        PreluareComandaPieseAuto();
                        break;

                    case "4":
                        FinalizeazaComandaPiese();
                        break;

                    case "5":
                        //admin.AdaugaCerereRezolvare(cereriRezolvare);
                        FaCerere(admin);
                        break;

                    case "6":
                        running = false;
                        break;

                    default:
                        _logger.LogError("Optiune invalida. Incercati din nou.");
                        break;
                }
            }
        }

        // Meniul pentru Mecanic
        private void MeniuMecanic(Mecanic mecanic)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMeniu Mecanic:");
                Console.WriteLine("1. Preia cerere rezolvare");
                Console.WriteLine("2. Investigare problema");
                Console.WriteLine("3. Rezolvare problema masina");
                Console.WriteLine("4. Iesire");
                Console.Write("Selectati o optiune: ");
                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        PreiaCerereRezolvare(mecanic);
                        break;

                    case "2":
                        InvestigareProblema();
                        break;

                    case "3":
                        RezolvareProblemaMasina(mecanic);
                        break;

                    case "4":
                        running = false;
                        break;

                    default:
                        _logger.LogError("Optiune invalida. Incercati din nou.");
                        break;
                }
            }
        }

        // Preia cerere de rezolvare (pentru Mecanic)
        private void PreiaCerereRezolvare(Mecanic mecanic)
        {
            mecanic.PreiaCerereRezolvare(cereriRezolvare);
        }

        //admin
        private void PreluareComandaPieseAuto()
        {
            Console.Write("Introduceti codul cererii de piese auto pentru preluare: ");
            string codCerere = Console.ReadLine();

            // Căutăm cererea de piese auto care este în stadiul 'AsteptareComanda'
            CererePieseAuto cererePiese = cereriPieseAuto.Find(c => c.CodCerere == codCerere && c.Status == StatusPiese.InAsteptare);

            if (cererePiese != null)
            {
                // Administratorul preia cererea și o procesează
                cererePiese.Status = StatusPiese.InAsteptare;
                _logger.LogInformation($"Comanda de piese auto cu codul {cererePiese.CodCerere} a fost preluata si comandata.");
                SalvareCereriPieseAuto();
            }
            else
            {
                _logger.LogWarning("Nu exista cereri de piese auto în stadiul 'Așteptare Comanda' cu acest cod.");
            }
        }

        //pt admin
        public void FinalizeazaComandaPiese()
        {
            Console.Write("Introduceti codul cererii de piese auto: ");
            string codCererePiese = Console.ReadLine();

            // Căutăm cererea de piese în lista de cereri de piese auto
            CererePieseAuto cererePiese = cereriPieseAuto.Find(c => c.CodCerere == codCererePiese && c.Status == StatusPiese.InAsteptare);

            if (cererePiese != null)
            {
                // Actualizăm statusul pieselor la 'Finalizat'
                cererePiese.Status = StatusPiese.Finalizat;
                Console.WriteLine($"Comanda de piese cu codul {cererePiese.CodCerere} a fost finalizata.");

                // Întrebăm utilizatorul care este codul cererii de rezolvare
                Console.Write("Introduceti codul cererii de rezolvare asociate: ");
                string codCerereRezolvare = Console.ReadLine();

                // Căutăm cererea de rezolvare asociată cererii de piese auto
                CerereRezolvare cerereRezolvare = cereriRezolvare.Find(c => c.CodCerere == codCerereRezolvare);

                if (cerereRezolvare != null)
                {
                    // Actualizăm cererea de rezolvare la statusul 'Finalizat'
                    cerereRezolvare.Status = StatusCerere.Finalizat;
                    _logger.LogInformation($"Comanda de piese cu codul {cererePiese.CodCerere} a fost finalizata.");
                    SalvareCereriPieseAuto();
                }
                else
                {
                    _logger.LogError("Nu s-a gasit cererea de rezolvare cu acest cod.");
                }
            }
            else
            {
                _logger.LogError("Nu exista o comanda de piese în așteptare cu acest cod.");
            }
        }


        private void InvestigareProblema()
        {
            Console.Write("Introduceti codul cererii pentru investigare: ");
            string codCerere = Console.ReadLine();

            // Căutăm cererea în lista de cereri care sunt în stadiul 'Investigare'
            CerereRezolvare cerere = cereriRezolvare.Find(c => c.CodCerere == codCerere && c.Status == StatusCerere.Investigare);

            if (cerere != null)
            {
                _logger.LogInformation($"Cererea {cerere.CodCerere} este în stadiul 'Investigare'.");

                // Întrebare pentru a verifica dacă sunt necesare piese auto
                Console.Write("Este necesara comandarea pieselor? (da/nu): ");
                string raspuns = Console.ReadLine().ToLower();

                if (raspuns == "da")
                {
                    // Permitem utilizatorului să introducă un cod pentru cererea de piese
                    Console.Write("Introduceti codul cererii de piese auto: ");
                    string codCererePiese = Console.ReadLine();

                    // Adăugăm cererea de piese în lista de cereri de piese auto
                    cereriPieseAuto.Add(new CererePieseAuto(codCererePiese, cerere.NumePersoana, StatusPiese.InAsteptare));

                    // Actualizez cererea de rezolvare la stadiul 'AsteptarePiese'
                    cerere.Status = StatusCerere.AsteptarePiese;
                    _logger.LogInformation($"Cererea {cerere.CodCerere} a fost actualizată la stadiul 'Asteptare Piese'.");
                    SalvareCereriPieseAuto();
                    SalvareCereriRezolvare();
                }
                
                else if (raspuns == "nu")
                {
                    // Daca nu sunt necesare piese, finalizam cererea
                    cerere.Status = StatusCerere.Finalizat;
                    Console.Write("Introduceti numele mecanicului care rezolva cererea: ");
                    string numeMecanic = Console.ReadLine();
            
                    cerere.RezolvatDe = numeMecanic;
                    _logger.LogInformation($"Problema masinii cu codul cererii {cerere.CodCerere} a fost rezolvata de {numeMecanic}, fara a mai comanda piese.");
                    SalvareCereriRezolvare();
                }
                else
                {
                    _logger.LogError("Raspuns invalid! Va rugam să răspundeti cu 'da' sau 'nu'.");
                }
            }
            else
            {
                _logger.LogError("Nu exista cereri în stadiul 'Investigare' cu acest cod.");
            }
        }


        // Rezolvare problema masina (pentru Mecanic)
        private void RezolvareProblemaMasina(Mecanic mecanic)
        {
            mecanic.RezolvaProblemaMasina(cereriRezolvare);
            SalvareCereriRezolvare();
        }
        
        private void FaCerere(Administrator administrator)
        {
            administrator.AdaugaCerereRezolvare(cereriRezolvare);
            SalvareCereriRezolvare();
        }

        // Adaugare utilizator
        private void AdaugaUtilizator()
        {
            Console.WriteLine("Introduceti datele utilizatorului:");
            Console.Write("Nume: ");
            string nume = Console.ReadLine();

            Console.Write("Prenume: ");
            string prenume = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Parola: ");
            string parola = Console.ReadLine();

            Console.WriteLine("Tip utilizator (1 - Administrator, 2 - Mecanic): ");
            string tipUtilizator = Console.ReadLine();

            Utilizator utilizator = null;

            if (tipUtilizator == "1")
            {
                utilizator = new Administrator(nume, prenume, email, parola, _logger);
            }
            else if (tipUtilizator == "2")
            {
                utilizator = new Mecanic(nume, prenume, email, parola, _logger);
            }

            if (utilizator != null)
            {
                utilizatori.Add(utilizator);
                _logger.LogInformation("Utilizatorul a fost adaugat cu succes!");
                SalvareUtilizatori();
            }
            else
            {
                _logger.LogError("Tip utilizator invalid.");
            }
        }

        // Salvarea utilizatorilor în fisier
        private void SalvareUtilizatori()
        {
            FileManager fileManager = new FileManager(filePath);
            fileManager.SaveToFile(utilizatori);
        }

        // Încărcarea utilizatorilor din fisier
        private void IncarcareUtilizatori()
        {
            FileManager fileManager = new FileManager(filePath);
            utilizatori = fileManager.LoadFromFile<Utilizator>();
            Console.WriteLine($"S-au incarcat {utilizatori.Count} utilizatori.");
        }
        
        private void SalvareCereriRezolvare()
        {
            string filePathRezolvare = "cereriRezolvare.json";
            FileManager fileManager = new FileManager(filePathRezolvare);
            fileManager.SaveToFile(cereriRezolvare);
            Console.WriteLine($"Au fost salvate {cereriRezolvare.Count} cereri de rezolvare.");
        }

        private void IncarcareCereriRezolvare()
        {
            string filePathRezolvare = "cereriRezolvare.json";
            FileManager fileManager = new FileManager(filePathRezolvare);
            cereriRezolvare = fileManager.LoadFromFile<CerereRezolvare>();
            Console.WriteLine($"S-au incarcat {cereriRezolvare.Count} cereri de rezolvare.");
        }

        public void SalvareCereriPieseAuto()
        {
            string filePathPieseAuto = "cereriPieseAuto.json";
            FileManager fileManager = new FileManager(filePathPieseAuto);
            fileManager.SaveToFile(cereriPieseAuto);
            Console.WriteLine($"Au fost salvate {cereriPieseAuto.Count} cereri de piese auto.");
        }

        private void IncarcareCereriPieseAuto()
        {
            string filePathPieseAuto = "cereriPieseAuto.json";
            FileManager fileManager = new FileManager(filePathPieseAuto);
            cereriPieseAuto = fileManager.LoadFromFile<CererePieseAuto>();
            Console.WriteLine($"S-au incarcat {cereriPieseAuto.Count} cereri de piese auto.");
        }

    }