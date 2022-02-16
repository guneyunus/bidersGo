using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using bidersGo.Application.Features.Commands.AddressCreate;
using bidersGo.Application.Features.Commands.AdminCreate;
using bidersGo.Application.Features.Commands.ModeratorCreate;
using bidersGo.Application.Features.Commands.StudentCreate;
using bidersGo.Application.Features.Commands.TeacherCreate;
using bidersGo.Application.Features.Queries.AddressGetById;
using bidersGo.Application.Features.Queries.AdminGetById;
using bidersGo.Application.Features.Queries.ModeratorGetById;
using bidersGo.Application.Features.Queries.StudentGetById;
using bidersGo.Application.Features.Queries.TeacherGetById;
using bidersGo.Domain.Entities;

namespace bidersGo.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Moderator, ModeratorGetByIdQueryResponse>().ReverseMap();
            CreateMap<Address, AddressGetByIdQueryResponse>().ReverseMap();
            CreateMap<Student, StudentByIdQueryResponse>().ReverseMap();
            CreateMap<Teacher, TeacherGetByIdQueryResponse>().ReverseMap();
            CreateMap<Admin, AdminGetByIdQueryResponse>().ReverseMap();
            CreateMap<Address, AddressCreateCommandResponse>().ReverseMap();
            CreateMap<Student, StudentCreateCommandResponse>().ReverseMap();
            CreateMap<Teacher, TeacherCreateCommandResponse>().ReverseMap();
            CreateMap<Moderator, ModeratorCreateCommandResponse>().ReverseMap();
            CreateMap<Admin, AdminCreateCommandResponse>().ReverseMap();




        }
    }
}
