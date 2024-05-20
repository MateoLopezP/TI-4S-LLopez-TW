namespace WebEins.Models
{
    public class Bestellung
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public double Menge { get; set; }
        
        public int ProdukteId { get; set; } // Fremdschlüssel der Produkte
        public int KündeId { get; set; } // Fremdschlüssel der Künde

        public Produkte? Produkte { get; set; }
        public Künde? Künde { get; set; }
    }
}
