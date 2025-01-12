namespace DefaultNamespace;

public abstract class Utilizator
{
   
    public string Nume { get;  }
    public string Prenume { get;  }
    public string Email { get;  }
    public string Parola { get;  }

    public Utilizator(string nume, string prenume, string email, string parola)
    {
        Nume = nume;
        Prenume = prenume;
        Email = email;
        Parola = parola;
    }

    public Utilizator(){ }
}