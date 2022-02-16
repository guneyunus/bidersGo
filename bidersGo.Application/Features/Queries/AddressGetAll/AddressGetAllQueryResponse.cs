using bidersGo.Application.Features.Queries.AddressGetById;
using System.Collections.Generic;

namespace bidersGo.Application.Features.Queries.AddressGetAll
{
    public class AddressGetAllQueryResponse
    {
      public  List<AddressGetByIdQueryResponse> AddressGetAll {get; set;}
    }
}
