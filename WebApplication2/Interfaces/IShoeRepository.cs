using WebApplication2.Model;

namespace WebApplication2.Interfaces;

public interface IShoeRepository
{
    Task<List<Shoe>> GetAllShoes();
    Task<Shoe> AddShoe(ShoeDTO newShoe);
    Task<Shoe> DeleteShoe(int id);
    Task<Shoe> UpdateShoe(int id, ShoeDTO newShoe);
    Task<Shoe> GetShoeById(int id);
}