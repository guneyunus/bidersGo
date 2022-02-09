using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGo.DataAcces.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminRepository AdminRepository { get; }
        IModeratorRepository ModeratorRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        IStudentRepository StudentRepository { get; }
        IAddressRepository AddressRepository { get; }
        ILessonRepository LessonRepository { get; }
        IMeetRepository MeetRepository { get; }
        void Save();
        Task<int> SaveAsync();

    }
}
