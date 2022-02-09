using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.DataAcces.Abstract;
using bidersGo.Entities;

namespace bidersGo.DataAcces.Conctare
{
    public class TeacherRepository:GenericRepository<TeacherRepository>,ITeacherRepository
    {
        private readonly BidersGoContext _context;

        public TeacherRepository(BidersGoContext context):base(context)
        {
            _context = context;
        }

        public Task AsyncUpdate(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public void Create(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public Address GetTeacherAdress(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Teacher GetTeacherById(Guid teacherGuid)
        {
            throw new NotImplementedException();
        }

        public Teacher GetTeacherByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Teacher> GetTeachersAll()
        {
            throw new NotImplementedException();
        }


        public void Update(Teacher entity)
        {
            throw new NotImplementedException();
        }

        Task<List<Teacher>> IRepository<Teacher>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Teacher> IRepository<Teacher>.GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
