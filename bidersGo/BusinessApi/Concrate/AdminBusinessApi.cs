using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Business.Abstract;
using bidersGo.DataAcces.Abstract;
using bidersGo.DataAcces.Conctare;
using bidersGo.Entities;

namespace bidersGo.BusinessApi.Concrate
{
    public class AdminBusinessApi : GenericBusinessApi<Admin>
    {
        private readonly BidersGoContext _context;
        private readonly IAdminService _adminService;
        private readonly IApplicationLogger _applicationLogger;
        private readonly IModeratorService _moderatorService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly IUnitOfWork _unitOfWork;
        public AdminBusinessApi(BidersGoContext context, IAdminService adminService, IApplicationLogger logger, IModeratorService moderatorService, IStudentService studentService, ITeacherService teacherService, IUnitOfWork unitOfWork)
        {
            _adminService = adminService;
            _applicationLogger = logger;
            _moderatorService = moderatorService;
            _studentService = studentService;
            _teacherService = teacherService;
            _unitOfWork = unitOfWork;
            _context = context;
        }



    }
}
