using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using bidersGo.Application.Features.Queries.TeacherGetById;
using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;

namespace bidersGo.Application.Features.Queries.TeacherOfLesson
{
    public class TeacherOfLessonQueryHandle : IRequestHandler<TeacherOfLessonQueryRequest, TeacherOfLessonQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TeacherOfLessonQueryHandle(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<TeacherOfLessonQueryResponse> Handle(TeacherOfLessonQueryRequest request, CancellationToken cancellationToken)
        {
            var teachers = _unitOfWork.TeacherRepository
                .GetTeachersAll()
                .Where(x => x.LessonId == request.Guid)
                .ToList();

            //var model = _mapper.Map<TeacherOfLessonQueryResponse>(teachers);

            var model = new TeacherOfLessonQueryResponse();
            foreach (var teacher in teachers)
            {
              model.Teachers.Add(_mapper.Map<TeacherGetByIdQueryResponse>(teacher));  
            }

            return Task.FromResult(model);

        }
    }
}
