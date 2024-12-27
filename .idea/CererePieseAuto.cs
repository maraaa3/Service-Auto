namespace DefaultNamespace;

public class CererePieseAuto
{
    public int Avb { get; set; }
    public string NumeUtilizator { get; set; }
    public string Detalii { get; set; }
    public StatusPiese Status { get; set; }

    public CererePieseAuto(int avb, string numeUtilizator, string detalii)
    {
        Avb = avb;
        NumeUtilizator = numeUtilizator;
        Detalii = detalii;
        Status = StatusPiese.InAsteptare;
    }

    public override string ToString()
    {
        return $"[AVB: {Avb}] {NumeUtilizator} - {Detalii} (Status: {Status})";
    }
}