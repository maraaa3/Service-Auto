namespace DefaultNamespace;

public class CerereRezolvare
{
      public string CodCerere { get; set; }
      public string NumePersoana { get; set; }
      public string NumarMasina { get; set; }
      public string DescriereProblema { get; set; }
      public StatusCerere Status { get; set; }
      public string RezolvatDe { get; set; }
      public CerereRezolvare(string codCerere, string numePersoana, string numarMasina, string descriereProblema, StatusCerere status)
      {
          CodCerere = codCerere;
          NumePersoana = numePersoana;
          NumarMasina = numarMasina;
          DescriereProblema = descriereProblema;
          Status = status;
          RezolvatDe = null;
      }
  }
    
   /* private bool IsValidNumarMasina(string numarMasina)
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
            if (CereriPiese.All(c => c.Status == StatusPiese.Finalizat)) // Toate piesele sunt disponibile
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
    }*/
