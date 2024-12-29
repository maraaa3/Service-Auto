namespace DefaultNamespace;

public class CerereRezolvare
{
    public string CodUnic { get; set; }
    public string NumeClient { get; set; }
    public string NumarMasina { get; set; }
    public string DescriereProblema { get; set; }
    public StatusCerere Status { get; set; }
    public string MecanicResponsabil { get; set; }
    public List<CererePieseAuto> CereriPiese { get; set; }

    public CerereRezolvare(string codUnic, string numeClient, string numarMasina, string descriereProblema)
    {   
        if (!IsValidNumarMasina(numarMasina))
        {
            throw new ArgumentException("Numarul de mașină nu este valid.Trebuie sa contina 7 caractere!!");
        }
        CodUnic = codUnic;
        NumeClient = numeClient;
        NumarMasina = numarMasina;
        DescriereProblema = descriereProblema;
        Status = StatusCerere.InPreluare;
        MecanicResponsabil = null; //ii pe null pana cand cnv preia comanda
        CereriPiese = new List<CererePieseAuto>();
    }
    
    private bool IsValidNumarMasina(string numarMasina)
    {
        // Exemplu de validare simpla: numarul masinii trebuie sa ca aiba exact 7 caractere
        return numarMasina.Length == 7;
    }
    public void AsociazaMecanic(string numeMecanic)
    {
        if (Status == StatusCerere.InPreluare)
        {
            MecanicResponsabil = numeMecanic;
            Status = StatusCerere.Investigare; // Actualizam starea
            Console.WriteLine($"Cererea {CodUnic} a fost alocată mecanicului {numeMecanic}.");
        }
        else
        {
            Console.WriteLine("Cererea nu poate fi alocata. Verificati starea.");
        }
    }
    
    public void AdaugaCererePiese(CererePieseAuto cerere)
    {
        CereriPiese.Add(cerere);
        Status = StatusCerere.AsteptarePiese;
        Console.WriteLine($"Cererea pentru piese {cerere.Avb} a fost adaugata.");
    }
    
    public void RezolvaProblema(bool necesitaPiese)
    {
        if (necesitaPiese)
        {
            if (CereriPiese.All(c => c.Status == StatusCerere.Finalizat)) // Toate piesele sunt disponibile
            {
                Status = StatusCerere.Finalizat;
                Console.WriteLine($"Cererea {CodUnic} a fost rezolvată cu succes de mecanicul {MecanicResponsabil}.");
            }
            else
            {
                Console.WriteLine("Nu toate piesele necesare sunt disponibile pentru a finaliza cererea.");
            }
        }
        else
        {
            Status = StatusCerere.Finalizat;
            Console.WriteLine($"Cererea {CodUnic} a fost rezolvată fără a comanda piese, de mecanicul {MecanicResponsabil}.");
        }
    }
    
    
    public override string ToString()
    {
        return $"[{CodUnic}] {NumeClient} - {NumarMasina} - {DescriereProblema} (Status: {Status})";
    }
}