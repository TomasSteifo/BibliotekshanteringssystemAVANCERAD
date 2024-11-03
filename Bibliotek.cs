public class Bibliotek
{
    public List<Bok> Bocker { get; set; } = new List<Bok>
        {
            new Bok { Id = 1, Titel = "C# Programming", ForfattareId = 1, Genre = "Programming", PubliceringsAr = 2021, Isbn = "123-4567890123", Recensioner = new List<int> { 5, 4, 3 } },
            new Bok { Id = 2, Titel = "Learn Python", ForfattareId = 2, Genre = "Programming", PubliceringsAr = 2020, Isbn = "234-5678901234", Recensioner = new List<int> { 4, 4, 5 } },
            new Bok { Id = 3, Titel = "JavaScript Essentials", ForfattareId = 3, Genre = "Programming", PubliceringsAr = 2019, Isbn = "345-6789012345", Recensioner = new List<int> { 5, 3, 4 } }
        };

    public List<Forfattare> Forfattare { get; set; } = new List<Forfattare>
        {
            new Forfattare { Id = 1, Namn = "Jane Doe", Land = "Sverige" },
            new Forfattare { Id = 2, Namn = "John Smith", Land = "USA" },
            new Forfattare { Id = 3, Namn = "Anna Svensson", Land = "Sverige" }
        };

    public void LaggTillBok()
    {
        Console.Write("Ange boktitel: ");
        string titel = Console.ReadLine();
        Console.Write("Ange författarens ID: ");
        if (!int.TryParse(Console.ReadLine(), out int forfattareId))
        {
            Console.WriteLine("Ogiltigt författar-ID.");
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

        int bokId = Bocker.Count + 1;
        Bocker.Add(new Bok { Id = bokId, Titel = titel, ForfattareId = forfattareId, Genre = genre, PubliceringsAr = publiceringsAr, Isbn = isbn });
        Console.WriteLine("Bok har lagts till.");
    }

    public void LaggTillForfattare()
    {
        Console.Write("Ange författarens namn: ");
        string namn = Console.ReadLine();
        Console.Write("Ange land: ");
        string land = Console.ReadLine();

        int forfattareId = Forfattare.Count + 1;
        Forfattare.Add(new Forfattare { Id = forfattareId, Namn = namn, Land = land });
        Console.WriteLine("Författare har lagts till.");
    }

    public void UppdateraBok()
    {
        Console.Write("Ange ID på boken som ska uppdateras: ");
        if (!int.TryParse(Console.ReadLine(), out int bokId) || !Bocker.Exists(b => b.Id == bokId))
        {
            Console.WriteLine("Bok med angivet ID hittades inte.");
            return;
        }
        var bok = Bocker.Find(b => b.Id == bokId);
        Console.Write("Ange ny titel (lämna tomt för att behålla nuvarande): ");
        string nyTitel = Console.ReadLine();
        if (!string.IsNullOrEmpty(nyTitel)) bok.Titel = nyTitel;

        Console.WriteLine("Bok har uppdaterats.");
    }

    public void UppdateraForfattare()
    {
        Console.Write("Ange ID på författaren som ska uppdateras: ");
        if (!int.TryParse(Console.ReadLine(), out int forfattareId) || !Forfattare.Exists(f => f.Id == forfattareId))
        {
            Console.WriteLine("Författare med angivet ID hittades inte.");
            return;
        }
        var forfattare = Forfattare.Find(f => f.Id == forfattareId);
        Console.Write("Ange nytt namn (lämna tomt för att behålla nuvarande): ");
        string nyttNamn = Console.ReadLine();
        if (!string.IsNullOrEmpty(nyttNamn)) forfattare.Namn = nyttNamn;

        Console.WriteLine("Författare har uppdaterats.");
    }

    public void TaBortBok()
    {
        Console.Write("Ange ID på boken som ska tas bort: ");
        if (!int.TryParse(Console.ReadLine(), out int bokId) || !Bocker.Exists(b => b.Id == bokId))
        {
            Console.WriteLine("Bok med angivet ID hittades inte.");
            return;
        }
        Bocker.RemoveAll(b => b.Id == bokId);
        Console.WriteLine("Bok har tagits bort.");
    }

    public void TaBortForfattare()
    {
        Console.Write("Ange ID på författaren som ska tas bort: ");
        if (!int.TryParse(Console.ReadLine(), out int forfattareId) || !Forfattare.Exists(f => f.Id == forfattareId))
        {
            Console.WriteLine("Författare med angivet ID hittades inte.");
            return;
        }
        Forfattare.RemoveAll(f => f.Id == forfattareId);
        Console.WriteLine("Författare har tagits bort.");
    }

    public void ListaBocker()
    {
        foreach (var bok in Bocker)
        {
            Console.WriteLine($"ID: {bok.Id}, Titel: {bok.Titel}, Författar-ID: {bok.ForfattareId}, Genre: {bok.Genre}, Publiceringsår: {bok.PubliceringsAr}, ISBN: {bok.Isbn}, Medelbetyg: {bok.Medelbetyg:F2}");
        }
    }

    public void ListaForfattare()
    {
        foreach (var forfattare in Forfattare)
        {
            Console.WriteLine($"ID: {forfattare.Id}, Namn: {forfattare.Namn}, Land: {forfattare.Land}");
            var bockerAvForfattare = Bocker.Where(b => b.ForfattareId == forfattare.Id);
            foreach (var bok in bockerAvForfattare)
            {
                Console.WriteLine($"  Bok: {bok.Titel}, Medelbetyg: {bok.Medelbetyg:F2}");
            }
        }
    }

    public void SokOchFiltreraBocker()
    {
        Console.WriteLine("\nVälj filteralternativ:");
        Console.WriteLine("1. Filtrera efter genre");
        Console.WriteLine("2. Filtrera efter författare");
        Console.WriteLine("3. Filtrera efter publiceringsår");
        Console.WriteLine("4. Lista böcker med genomsnittligt betyg över ett tröskelvärde");
        Console.WriteLine("5. Sortera böcker");
        Console.Write("Välj ett alternativ: ");

        switch (Console.ReadLine())
        {
            case "1":
                Console.Write("Ange genre: ");
                string genre = Console.ReadLine();
                var filtreradeGenre = Bocker.Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
                foreach (var bok in filtreradeGenre)
                {
                    Console.WriteLine($"Titel: {bok.Titel}, Genre: {bok.Genre}");
                }
                break;
            case "2":
                Console.Write("Ange författarens ID: ");
                if (int.TryParse(Console.ReadLine(), out int forfattareId))
                {
                    var filtreradeForfattare = Bocker.Where(b => b.ForfattareId == forfattareId);
                    foreach (var bok in filtreradeForfattare)
                    {
                        Console.WriteLine($"Titel: {bok.Titel}, Författar-ID: {bok.ForfattareId}");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt författar-ID.");
                }
                break;
            case "3":
                Console.Write("Ange publiceringsår: ");
                if (int.TryParse(Console.ReadLine(), out int publiceringsAr))
                {
                    var filtreradeAr = Bocker.Where(b => b.PubliceringsAr == publiceringsAr);
                    foreach (var bok in filtreradeAr)
                    {
                        Console.WriteLine($"Titel: {bok.Titel}, Publiceringsår: {bok.PubliceringsAr}");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt år.");
                }
                break;
            case "4":
                Console.Write("Ange tröskelvärde för betyg (1-5): ");
                if (double.TryParse(Console.ReadLine(), out double tröskelvärde))
                {
                    var filtreradeBetyg = Bocker.Where(b => b.Medelbetyg > tröskelvärde);
                    foreach (var bok in filtreradeBetyg)
                    {
                        Console.WriteLine($"Titel: {bok.Titel}, Medelbetyg: {bok.Medelbetyg:F2}");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt värde.");
                }
                break;
            case "5":
                Console.WriteLine("Sortera böcker efter:");
                Console.WriteLine("1. Publiceringsår");
                Console.WriteLine("2. Titel");
                Console.WriteLine("3. Författarens namn");
                Console.Write("Välj ett alternativ: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        var sorteradeAr = Bocker.OrderBy(b => b.PubliceringsAr);
                        foreach (var bok in sorteradeAr)
                        {
                            Console.WriteLine($"Titel: {bok.Titel}, Publiceringsår: {bok.PubliceringsAr}");
                        }
                        break;
                    case "2":
                        var sorteradeTitel = Bocker.OrderBy(b => b.Titel);
                        foreach (var bok in sorteradeTitel)
                        {
                            Console.WriteLine($"Titel: {bok.Titel}");
                        }
                        break;
                    case "3":
                        var sorteradeForfattare = Bocker.OrderBy(b => Forfattare.FirstOrDefault(f => f.Id == b.ForfattareId)?.Namn);
                        foreach (var bok in sorteradeForfattare)
                        {
                            var forfattareNamn = Forfattare.FirstOrDefault(f => f.Id == bok.ForfattareId)?.Namn;
                            Console.WriteLine($"Titel: {bok.Titel}, Författare: {forfattareNamn}");
                        }
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val.");
                        break;
                }
                break;
            default:
                Console.WriteLine("Ogiltigt val.");
                break;
        }
    }
}