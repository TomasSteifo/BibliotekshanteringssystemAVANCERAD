// LibraryDataHandler class: Hanterar in- och utläsning av data till och från JSON-filen.
using System.Text.Json;
using System.Xml;

public static class LibraryDataHandler
{
    public static Bibliotek LaddaDataFrånFil()
    {
        try
        {
            string filePath = "LibraryData.json";
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                var bibliotek = JsonSerializer.Deserialize<Bibliotek>(jsonData);
                return bibliotek ?? new Bibliotek { Bocker = new List<Bok>(), Forfattare = new List<Forfattare>() };
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ett fel inträffade vid laddning av data: {ex.Message}");
        }
        return new Bibliotek { Bocker = new List<Bok>(), Forfattare = new List<Forfattare>() };
    }

    public static void SparaDataTillFil(Bibliotek bibliotek)
    {
        try
        {
            string filePath = "LibraryData.json";
            string jsonData = JsonSerializer.Serialize(bibliotek, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine("Data har sparats till filen LibraryData.json.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ett fel inträffade vid sparning av data: {ex.Message}");
        }
    }
}


