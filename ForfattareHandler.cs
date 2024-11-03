// FörfattareHandler class: Statiska metoder för att hantera operationer på författare.
public static class ForfattareHandler
{
    public static void LaggTillForfattare(List<Forfattare> forfattare)
    {
        Console.Write("Ange författarens namn: ");
        string namn = Console.ReadLine();
        Console.Write("Ange land: ");
        string land = Console.ReadLine();

        int forfattareId = forfattare.Any() ? forfattare.Max(f => f.Id) + 1 : 1;
        forfattare.Add(new Forfattare { Id = forfattareId, Namn = namn, Land = land });
    }

    public static void UppdateraForfattare(List<Forfattare> forfattare)
    {
        // Implementera kod för att uppdatera författardetaljer
    }

    public static void TaBortForfattare(List<Forfattare> forfattare)
    {
        // Implementera kod för att ta bort en författare
    }

    public static void ListaForfattare(List<Forfattare> forfattare)
    {
        // Implementera kod för att lista alla författare
    }
}