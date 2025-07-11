using ZapazAPI.Models;

namespace ZapazAPI.Repository
{
    public interface IZapazRepo
    {
        //GET 
        Task<IEnumerable<Zapa>> GetZapas();
        Task<Zapa?> GetZapaId(int id);
        Task<IEnumerable<Zapa>> GetZapaAv(bool available);
        Task<IEnumerable<Zapa>> GetZapaSize(double size);
        Task<IEnumerable<Zapa>> GetZapaColor(string color);
        Task<IEnumerable<Zapa>> GetZapaSport(string sport);
        Task<IEnumerable<Zapa>> GetZapaBrand(string brand);
        Task<IEnumerable<Zapa>> GetZapaModel(string model);
        Task<IEnumerable<Zapa>> GetZapaGenre(string genre);
        Task<IEnumerable<Zapa>> GetCustomZapa(string filter);

        //PUT 
        Task PutZapa(int id, Zapa zapa);

        //POST 
        Task<Zapa> PostZapa(Zapa zapa);

        //DELETE 
        Task DeleteZapa(int id);
    }
}
