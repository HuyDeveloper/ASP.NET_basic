using WebApplication2.Interfaces;
using WebApplication2.Model;

namespace WebApplication2.Services;

public class ShoeServices: IShoeServices
{
    private readonly IShoeRepository _shoeRepository;
    
    public ShoeServices(IShoeRepository shoeRepository)
    {
        _shoeRepository = shoeRepository;
    }

    public async Task<List<Shoe>> getAllShoes()
    {
        var result = await _shoeRepository.GetAllShoes();
        return result;
    }
    public async Task<Shoe> AddShoe(ShoeDTO newShoe)
    {
        var result = await _shoeRepository.AddShoe(newShoe);
        return result;
    }
    public async Task<Shoe> DeleteShoe(int id)
    {
        var result = await _shoeRepository.DeleteShoe(id);
        return result;
    }
    public async Task<Shoe> UpdateShoe(int id, ShoeDTO newShoe)
    {
        var result = await _shoeRepository.UpdateShoe(id, newShoe);
        return result;
    }
    public async Task<Shoe> GetShoeById(int id)
    {
        var result = await _shoeRepository.GetShoeById(id);
        return result;
    }
    
}