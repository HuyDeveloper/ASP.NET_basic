using MediatR;
using WebApplication2.Interfaces;
using WebApplication2.Model;

namespace WebApplication2.Queries;

public class GetAllShoesQuery : IRequest<List<Shoe>>
{
}