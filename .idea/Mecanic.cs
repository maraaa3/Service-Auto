namespace DefaultNamespace;

public class Mecanic : Utilizator
{
    public Mecanic(string codUnic, string nume, string prenume, string email, string parola)
        : base(codUnic, nume, prenume, email, parola) { }

    public override void Meniu()
    {
        Console.WriteLine("Meniu Mecanic:");
        Console.WriteLine("1. Preluare cerere rezolvare.");
        Console.WriteLine("2. Investigare problema.");
        Console.WriteLine("3. Creare cerere piese auto.");
        Console.WriteLine("4. Rezolvare problema masina.");
        Console.WriteLine("5. Deconectare.");
    }
}