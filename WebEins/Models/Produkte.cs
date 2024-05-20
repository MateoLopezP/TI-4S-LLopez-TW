namespace WebEins.Models
{
    public class Produkte
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public decimal Preis { get; set; }
        public double Betrag { get; set; }

        public List<Bestellung> Bestellungen { get; set; }
    }
}