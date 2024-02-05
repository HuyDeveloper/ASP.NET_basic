using WebApplication2.Model;

namespace WebApplication2.Interfaces;

public interface IShoeServices
{
     Task<List<Shoe>> getAllShoes();
     Task<Shoe> AddShoe(ShoeDTO newShoe);
     Task<Shoe> DeleteShoe(int id);
     Task<Shoe> UpdateShoe(int id, ShoeDTO newShoe);
     Task<Shoe> GetShoeById(int id);
}