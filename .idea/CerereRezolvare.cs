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
    
   
