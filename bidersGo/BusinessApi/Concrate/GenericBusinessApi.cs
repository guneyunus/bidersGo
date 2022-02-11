using bidersGo.Business.Abstract;
using bidersGo.DataAcces.Abstract;
using bidersGo.DataAcces.Conctare;
using Microsoft.EntityFrameworkCore;

namespace bidersGo.BusinessApi.Concrate
{
    public class GenericBusinessApi<Tentity> where Tentity : class
    {
        private readonly IAdminService _adminService;
        private readonly IApplicationLogger _applicationLogger;
        private readonly IModeratorService _moderatorService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BidersGoContext _context;

        public GenericBusinessApi()
        {
            
        }
        public GenericBusinessApi(BidersGoContext context,IAdminService adminService,IApplicationLogger logger,IModeratorService moderatorService,IStudentService studentService,ITeacherService teacherService,IUnitOfWork unitOfWork)
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
