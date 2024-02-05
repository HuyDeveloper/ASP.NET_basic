using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Interfaces;
using WebApplication2.Model;

namespace WebApplication2.Repository;

public class ShoeRepository :IShoeRepository
{
    private readonly Context _context;
    private readonly IMapper _mapper;
    public ShoeRepository(Context dbContext, IMapper mapper)
    {
        _context = dbContext;
        _mapper = mapper;
    }

    public async Task<List<Shoe>> GetAllShoes()
    {
        var result = await _context.Shoes.ToListAsync();
        return result;
    }

    public async Task<Shoe> AddShoe(ShoeDTO newShoe)
    {
        var cart = new Cart {};
        Shoe shoe = new Shoe();
        _mapper.Map(newShoe, shoe);
        cart.Shoes.Add(shoe);
        await _context.Carts.AddAsync(cart);
        await _context.SaveChangesAsync();
        return shoe;
    }
    public async Task<Shoe> DeleteShoe(int id)
    {
        var shoe = await _context.Shoes.FindAsync(id);
        if (shoe == null)
        {
            return null;
        }
        _context.Shoes.Remove(shoe);
        await _context.SaveChangesAsync();
        return shoe;
    }
    public async Task<Shoe> UpdateShoe(int id, ShoeDTO newShoe)
    {
        var shoe = await _context.Shoes.FindAsync(id);
        if (shoe == null)
        {
            return null;
        }
        _mapper.Map<ShoeDTO, Shoe>(newShoe, shoe);
        await _context.SaveChangesAsync();
        return shoe;
    }
    public async Task<Shoe> GetShoeById(int id)
    {
        var shoe = await _context.Shoes.FindAsync(id);
        return shoe;
    }
}