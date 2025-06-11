namespace ZapazAPI.Models
{
    public class Zapa
    {
        public required string Id { get; set; }
        public required string Brand { get; set; }
        public required string Model { get; set; }
        public required string SportType { get; set; }
        public required string Category { get; set; }
        public required int Size { get; set; }
        public required string Color { get; set; }
        public required bool Available { get; set; }
        public required int Stock { get; set; }
    }
}
