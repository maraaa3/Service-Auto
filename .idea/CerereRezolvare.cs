namespace DefaultNamespace;

public class CerereRezolvare
{
    public string CodUnic { get; set; }
    public string NumeClient { get; set; }
    public string NumarMasina { get; set; }
    public string DescriereProblema { get; set; }
    public StatusCerere Status { get; set; }

    public CerereRezolvare(string codUnic, string numeClient, string numarMasina, string descriereProblema)
    {
        CodUnic = codUnic;
        NumeClient = numeClient;
        NumarMasina = numarMasina;
        DescriereProblema = descriereProblema;
        Status = StatusCerere.InPreluare;
    }

    public override string ToString()
    {
        return $"[{CodUnic}] {NumeClient} - {NumarMasina} - {DescriereProblema} (Status: {Status})";
    }
}