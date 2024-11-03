// LibraryDataHandler class: Hanterar in- och utläsning av data till och från JSON-filen.
using System.Text.Json;

public static class LibraryDataHandler
{
    private const string Filnamn = "LibraryData.json";

    public static Bibliotek LaddaDataFrånFil()
    {
        if (!File.Exists(Filnamn))
        {
            return new Bibliotek();
        }

        string json = File.ReadAllText(Filnamn);
        return JsonSerializer.Deserialize<Bibliotek>(json) ?? new Bibliotek();
    }

    public static void SparaDataTillFil(Bibliotek bibliotek)
    {
        string json = JsonSerializer.Serialize(new { Böcker = bibliotek.Bocker, Författare = bibliotek.Forfattare }, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(Filnamn, json);
    }
}