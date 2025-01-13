namespace DefaultNamespace;

using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;

public class Administrator : Utilizator
{
    [JsonIgnore]
    private ILogger<AplicatiaPrincipala>? _logger;

    public Administrator(string nume, string prenume, string email, string parola, ILogger<AplicatiaPrincipala> logger)
        : base(nume, prenume, email, parola)
    {
        _logger = logger;
    }

    public Administrator() : base()
    {

    }

    public void SetLoggerAfterDeserialization(ILogger<AplicatiaPrincipala> logger)
    {
        _logger = logger;        
    }

    public void VizualizeazaCereri(List<CerereRezolvare> cereri)
    {
        if (cereri.Count == 0)
        {
            _logger.LogWarning("Lista de cereri este goală.");
            return;
        }
        
        foreach (var cerere in cereri)
        {
            _logger.LogInformation($"Cerere ID: {cerere.CodCerere}, Status: {cerere.Status}");
        }
    }

    public void VizualizeazaComandaPiese(List<CererePieseAuto> cereriPiese)
    {
        foreach (var cerere in cereriPiese)
        {
            _logger.LogInformation($"Comanda piesa ID: {cerere.CodCerere}, Status: {cerere.Status}");
        }
    }

    public void AdaugaCerereRezolvare(List<CerereRezolvare> cereri)
    {
        Console.Write("Introduceti codul cererii: ");
        string codCerere = Console.ReadLine();
        Console.Write("Introduceti numele persoanei: ");
        string numePersoana = Console.ReadLine();
        Console.Write("Introduceti numarul masinii: ");
        string numarMasina = Console.ReadLine();
        Console.Write("Introduceti descrierea problemei: ");
        string descriereProblema = Console.ReadLine();

        CerereRezolvare cerere = new CerereRezolvare(codCerere, numePersoana, numarMasina, descriereProblema, StatusCerere.InPreluare);
        cereri.Add(cerere);
        _logger.LogInformation("Cererea a fost adaugata.");
    }
}