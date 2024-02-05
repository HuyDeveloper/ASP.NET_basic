using System.Security.Cryptography;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Interfaces;
using WebApplication2.Model;
using WebApplication2.Queries;

namespace WebApplication2;

[ApiController]
public class ShoeController : ControllerBase
{
    // GET
    private Context _context;
    private readonly IMediator _mediator;
    private readonly IShoeServices _shoeServices;
    public ShoeController(Context context, IShoeServices shoeServices, IMediator mediator)
    {
        _context = context;
        _shoeServices = shoeServices;
        _mediator = mediator;
    }

    [HttpGet]
    [Route("[controller]/getAllShoes")]
    public async Task<IActionResult> GetAllProduct()
    {
        //Search value by variable can create parameter in query, sent to database
        //Example: SELECT * FROM product WHERE id = @id
        //where(id = @id) => can create sql injection
        var result = await _mediator.Send(new GetAllShoesQuery());
        return Ok(result);
    }

    [HttpPost]
    [Route("[controller]/addShoe")]
    public async Task<IActionResult> AddProduct([FromBody] ShoeDTO NewShoe)
    {
        var result = await _shoeServices.AddShoe(NewShoe);
        return Ok(result);
    }

    [HttpPut]
    [Route("[controller]/updateShoe/{id}")]
    public async Task<IActionResult> updateProduct([FromRoute] int id, [FromBody] ShoeDTO newshoe)
    {
         var result = await _shoeServices.UpdateShoe(id, newshoe);
         if (result == null)
         {
             return NotFound();
         }

         return Ok(result);
    }

    [HttpDelete]
    [Route("[controller]/deleteShoe/{id}")]
    public async Task<IActionResult> deleteProduct([FromRoute] int id)
    {
        var result = await _shoeServices.DeleteShoe(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    
    [HttpGet]
    [Route("[controller]/getShoeById/{id}")]
    public async Task<IActionResult> GetShoeById([FromRoute] int id)
    {
        var result = await _shoeServices.GetShoeById(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    
    //Eager loading lấy toàn bộ thông tin của entity con khi lấy entity cha ngay lập tức(dùng Include để lấy thông tin entity con)
    //Lazy loading lấy thông tin khi người dùng bắt đầu truy cập vào entity con(hành vi mac dinh)
}