namespace ZapazAPI.Models
{
    public class Zapa
    {
        public required string Id { get; set; }
        public required string Marca { get; set; }
        public required string Modelo { get; set; }
        public required int Talle { get; set; }
        public required string Color { get; set; }
        public required bool Disponible { get; set; }
        public required int Stock { get; set; }
    }
}
