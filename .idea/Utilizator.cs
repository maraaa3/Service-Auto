namespace DefaultNamespace;

public abstract class Utilizator
{
    public string CodUnic { get;  }
    public string Nume { get;  }
    public string Prenume { get;  }
    public string Email { get;  }
    public string Parola { get;  }

    protected Utilizator(string codUnic, string nume, string prenume, string email, string parola)
    {
        CodUnic = codUnic;
        Nume = nume;
        Prenume = prenume;
        Email = email;
        Parola = parola;
    }

    public abstract void Meniu();
}