using MediatR;
using WebApplication2.Interfaces;
using WebApplication2.Model;
using WebApplication2.Queries;

namespace WebApplication2.Handlers;

public class GetAllShoeHandler: IRequestHandler<GetAllShoesQuery, List<Shoe>>
{
    private readonly IShoeRepository _shoeRepository;
    
public GetAllShoeHandler(IShoeRepository shoeRepository)
    {
        _shoeRepository = shoeRepository;
    }
    
    public async Task<List<Shoe>> Handle(GetAllShoesQuery request, CancellationToken cancellationToken)
    {
        var result = await _shoeRepository.GetAllShoes();
        return result;
    }
}