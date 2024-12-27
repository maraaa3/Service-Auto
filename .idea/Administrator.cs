namespace DefaultNamespace;

public class Administrator : Utilizator
{
    public Administrator(string codUnic, string nume, string prenume, string email, string parola)
        : base(codUnic, nume, prenume, email, parola) { }

    public override void Meniu()
    {
        Console.WriteLine("Meniu Administrator:");
        Console.WriteLine("1. Vizualizare cereri rezolvare probleme.");
        Console.WriteLine("2. Vizualizare comenzi piese auto.");
        Console.WriteLine("3. Preluare si finalizare comenzi piese auto.");
        Console.WriteLine("4. Adaugare cerere rezolvare probleme.");
        Console.WriteLine("5. Deconectare.");
    }
}
