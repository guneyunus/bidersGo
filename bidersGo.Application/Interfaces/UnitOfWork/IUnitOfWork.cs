using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bidersGo.Domain.Entities;
using System.Threading.Tasks;
using bidersGo.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace bidersGo.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
        IAdminRepository AdminRepository { get; }
        IModeratorRepository ModeratorRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        IStudentRepository StudentRepository { get; }
        IAddressRepository AddressRepository { get; }
        ILessonRepository LessonRepository { get; }
        IMeetRepository MeetRepository { get; }
        IWorkingWeekRepository workingWeekRepository { get; }
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        void Save();
        Task<int> SaveAsync();
    }
}
