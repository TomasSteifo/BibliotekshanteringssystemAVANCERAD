public class Bok
{
    public int Id { get; set; }
    public string Titel { get; set; }
    public int ForfattareId { get; set; }
    public string Genre { get; set; }
    public int PubliceringsAr { get; set; }
    public string Isbn { get; set; }
    public List<int> Recensioner { get; set; } = new List<int>();

    public double Medelbetyg => Recensioner.Any() ? Recensioner.Average() : 0;
}