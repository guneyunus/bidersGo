using AutoMapper;
using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.TeacherGetByLesson
{
    public class TeacherGetByLessonQueryHandler : IRequestHandler<TeacherGetByLessonQueryRequest, TeacherGetByLessonQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TeacherGetByLessonQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<TeacherGetByLessonQueryResponse> Handle(TeacherGetByLessonQueryRequest request, CancellationToken cancellationToken)
        {
            var teacher = _unitOfWork.TeacherRepository.GetTeacherById(request.LessonId);

            TeacherGetByLessonQueryResponse model = _mapper.Map<TeacherGetByLessonQueryResponse>(teacher);
            return Task<TeacherGetByLessonQueryResponse>.FromResult(model);
        }
    }
}
