using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Model;

namespace WebApplication2;

[ApiController]
public class TestingController : ControllerBase
{
    // GET
    private Context _context;
    public TestingController(Context context)
    {
        _context = context;
    }
    [HttpGet]
    [Route("[controller]/a")]
    public List<Product> GetByIdProduct()
    {
        //Search value by variable can create parameter in query, sent to database
        //Example: SELECT * FROM product WHERE id = @id
        //where(id = @id) => can create sql injection
        return new List<Product>(_context.Products.ToList().OrderBy(o=>o.price));
    }

    [HttpGet]
    [Route("[controller]/b")]
    public string AddProduct()
    {
        var product = new Product("name", "brand", 1);
        _context.Products.Add(product);
        _context.SaveChanges();
        return "Add product succesfully";
    }
}