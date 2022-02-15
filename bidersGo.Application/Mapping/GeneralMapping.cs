using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using bidersGo.Application.Features.Commands.AddressCreate;
using bidersGo.Application.Features.Queries.StudentGetById;
using bidersGo.Domain.Entities;

namespace bidersGo.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Student, StudentByIdQueryResponse>().ReverseMap();
            CreateMap<Address, AddressCreateCommandResponse>().ReverseMap();
        }
    }
}
