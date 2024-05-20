namespace WebEins.Models
{
    public class Künde
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public string Addresse { get; set; }
        public string Personalnummer { get; set; }
        public string Ausweisidentificactionsnummer { get; set; }

        public List<Bestellung> Bestellungen { get; set; }

    }
}
