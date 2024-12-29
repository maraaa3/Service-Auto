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

	public void FinalizeazaCerere()
    {
         if (Status == StatusPiese.InAsteptare) // Verificam daca cererea este in asteptare
        {
            Status = StatusPiese.Finalizat;
            Console.WriteLine($"Cererea de piese {Avb} a fost finalizata.");
        }
        else
        {
            Console.WriteLine($"Cererea de piese {Avb} nu poate fi finalizata deoarece nu este în asteptare.");
        }
    }

    public override string ToString()
    {
        return $"[AVB: {Avb}] {NumeUtilizator} - {Detalii} (Status: {Status})";
    }
}