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
using bidersGo.Application.Features.Commands.TeacherWorkingHoursCreate;
using bidersGo.Application.Features.Queries.AddressGetAll;
using bidersGo.Application.Features.Queries.AddressGetById;
using bidersGo.Application.Features.Queries.AdminGetById;
using bidersGo.Application.Features.Queries.LessonGetAll;
using bidersGo.Application.Features.Queries.LessonGetById;
using bidersGo.Application.Features.Queries.ModeratorGetById;
using bidersGo.Application.Features.Queries.RoleGetById;
using bidersGo.Application.Features.Queries.StudentGetById;
using bidersGo.Application.Features.Queries.TeacherGetById;
using bidersGo.Application.Features.Queries.TeacherOfLesson;
using bidersGo.Application.Features.Queries.UserGetById;
using bidersGo.Domain.Entities;
using bidersGo.Domain.Entities.Identity;

namespace bidersGo.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Moderator, ModeratorGetByIdQueryResponse>().ReverseMap();
            CreateMap<Address, AddressGetByIdQueryResponse>();
            CreateMap<Student, StudentByIdQueryResponse>().ReverseMap();
            CreateMap<Teacher, TeacherGetByIdQueryResponse>().ReverseMap();
            CreateMap<Admin, AdminGetByIdQueryResponse>().ReverseMap();
            CreateMap<AddressCreateCommandResponse, Address>();
            CreateMap<Student, StudentCreateCommandResponse>().ReverseMap();
            CreateMap<Teacher, TeacherCreateCommandResponse>().ReverseMap();
            CreateMap<Moderator, ModeratorCreateCommandResponse>().ReverseMap();
            CreateMap<Admin, AdminCreateCommandResponse>().ReverseMap();
            CreateMap<AddressGetAllQueryResponse, Address>();
            CreateMap<Lesson, LessonGetByIdQueryResponse>().ReverseMap();
            CreateMap<WorkingForOneHour, TeacherWorkingHoursCreateCommandRequest>().ReverseMap();
            CreateMap<ApplicationUser, UserGetByIdQueryResponse>().ReverseMap();
            CreateMap<ApplicationRole, RoleGetByIdQueryResponse>().ReverseMap();



        }
    }
}
