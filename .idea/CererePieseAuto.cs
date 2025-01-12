namespace DefaultNamespace;

public class CererePieseAuto
{
    public string CodCerere { get; set; }
    public string NumeUtilizator { get; set; }
    public StatusPiese Status { get; set; }

    public CererePieseAuto(string codCerere, string numeUtilizator, StatusPiese status)
    {
        CodCerere = codCerere;
        NumeUtilizator = numeUtilizator;
        Status = status;
    }

	/*public void FinalizeazaCerere()
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
    }*/
}