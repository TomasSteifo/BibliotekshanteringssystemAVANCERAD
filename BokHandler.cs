// BokHandler class: Statiska metoder för att hantera operationer på böcker.
public static class BokHandler
{
    public static void LaggTillBok(List<Bok> bocker, List<Forfattare> forfattare)
    {
        Console.Write("Ange boktitel: ");
        string titel = Console.ReadLine();
        Console.Write("Ange författarens ID: ");
        if (!int.TryParse(Console.ReadLine(), out int forfattareId) || !forfattare.Exists(f => f.Id == forfattareId))
        {
            Console.WriteLine("Ogiltigt författare-ID.");
            return;
        }

        Console.Write("Ange genre: ");
        string genre = Console.ReadLine();
        Console.Write("Ange publiceringsår: ");
        if (!int.TryParse(Console.ReadLine(), out int publiceringsAr))
        {
            Console.WriteLine("Ogiltigt år.");
            return;
        }

        Console.Write("Ange ISBN: ");
        string isbn = Console.ReadLine();

        int bokId = bocker.Any() ? bocker.Max(b => b.Id) + 1 : 1;
        bocker.Add(new Bok { Id = bokId, Titel = titel, ForfattareId = forfattareId, Genre = genre, PubliceringsAr = publiceringsAr, Isbn = isbn });
    }

    public static void UppdateraBok(List<Bok> bocker)
    {
        // Implementera kod för att uppdatera bokdetaljer
    }

    public static void TaBortBok(List<Bok> bocker)
    {
        // Implementera kod för att ta bort en bok
    }

    public static void ListaBocker(List<Bok> bocker, List<Forfattare> forfattare)
    {
        // Implementera kod för att lista alla böcker
    }

    public static void SokOchFiltreraBocker(List<Bok> bocker)
    {
        // Implementera kod för att söka och filtrera böcker
    }
}