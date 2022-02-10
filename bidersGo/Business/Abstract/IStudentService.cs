using bidersGo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace bidersGo.Business.Abstract
{
    public interface IStudentService : IValidator<Student>
    {
        List<Teacher> GetTeachersAll();
    
       
        List<Lesson> GetLessonsAll();
        List<Meet> GetMeetsByTeacher(Teacher teacher);

        //List<Meet> GetMeetsAll(Student student); kendine ait olanlar i�in.Student id den getirmeyi denedim ama hata ald�m ondan yorum sat�r� :-)











    }

}

