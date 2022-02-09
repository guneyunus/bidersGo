using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.DataAcces.Abstract;

namespace bidersGo.DataAcces.Conctare
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly BidersGoContext _context;

        public UnitOfWork(BidersGoContext context) 
        {
            _context = context;
        }

        private  AdminRepository _adminRepository;
        private  ModeratorRepository _moderatorRepository;
        private  TeacherRepository _teacherRepository;
        private StudentRepository _studentRepository;
        private  LessonRepository _lessonRepository;
        private  MeetRepository _meetRepository;
        private  AddressRepository _addressRepository;

        public IAdminRepository AdminRepository =>_adminRepository = _adminRepository ?? new AdminRepository(_context);

        public IModeratorRepository ModeratorRepository =>
            _moderatorRepository = _moderatorRepository ?? new ModeratorRepository(_context);

        public ITeacherRepository TeacherRepository =>
            _teacherRepository = _teacherRepository ?? new TeacherRepository(_context);

        public IStudentRepository StudentRepository =>
            _studentRepository = _studentRepository ?? new StudentRepository(_context);

        public IAddressRepository AddressRepository =>
            _addressRepository = _addressRepository ?? new AddressRepository(_context);

        public ILessonRepository LessonRepository =>
            _lessonRepository = _lessonRepository ?? new LessonRepository(_context);

        public IMeetRepository MeetRepository => _meetRepository = _meetRepository ?? new MeetRepository(_context);

        public void Dispose()
        {
            _context.Dispose(); 
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
