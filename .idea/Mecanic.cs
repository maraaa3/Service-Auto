namespace DefaultNamespace;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;

public class Mecanic : Utilizator
{
    [JsonIgnore]
    private ILogger<AplicatiaPrincipala>? _logger;

    public Mecanic(string nume, string prenume, string email, string parola, ILogger<AplicatiaPrincipala> logger)
        : base(nume, prenume, email, parola)
    {
        _logger = logger;
    }

    public Mecanic() : base()
    {

    }

    public void SetLoggerAfterDeserialization(ILogger<AplicatiaPrincipala> logger)
    {
        _logger = logger;
    }

    public void PreiaCerereRezolvare(List<CerereRezolvare> cereri)
    {
        CerereRezolvare cerere = cereri.Find(c => c.Status == StatusCerere.InPreluare);
        if (cerere != null)
        {
            cerere.Status = StatusCerere.Investigare;
            _logger.LogInformation($"Cererea cu codul {cerere.CodCerere} a fost preluata.");
        }
        else
        {
            _logger.LogWarning("Nu exista cereri disponibile pentru preluare.");
        }
    }

    public void RezolvaProblemaMasina(List<CerereRezolvare> cereri)
    {
        Console.Write("Introduceti codul cererii pentru rezolvare: ");
        string codCerere = Console.ReadLine();
        CerereRezolvare cerere = cereri.Find(c => c.CodCerere == codCerere);

        if (cerere != null && cerere.Status == StatusCerere.Finalizat)
        {
            Console.Write("Introduceti numele mecanicului care rezolva cererea: ");
            string numeMecanic = Console.ReadLine();
            
            cerere.RezolvatDe = numeMecanic;
            _logger.LogInformation($"Problema masinii cu codul cererii {cerere.CodCerere} a fost rezolvata de {numeMecanic}.");
        }
        else if (cerere != null && cerere.Status == StatusCerere.AsteptarePiese)
        {
            _logger.LogWarning($"Problema masinii cu codul cererii {cerere.CodCerere} are nevoie mai intai de piese auto.");
        }
            else
        {
            _logger.LogInformation("Cererea trebuie investigata.");
        }
    }
}