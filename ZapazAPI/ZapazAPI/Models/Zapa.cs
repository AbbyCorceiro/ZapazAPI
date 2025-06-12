namespace ZapazAPI.Models
{
    public class Zapa
    {
        public required int Id { get; set; }
        public required string Brand { get; set; }
        public required string Model { get; set; }
        public required string SportType { get; set; }
        public required string Genre { get; set; }
        public required double Size { get; set; }
        public required string Color { get; set; }
        public double? Price { get; set; }
        public required bool Available { get; set; }
        public required int Stock { get; set; }
    }
}
