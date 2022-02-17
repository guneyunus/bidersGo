using AutoMapper;
using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.LessonGetAll
{
    public class LessonGetAllQueryHandler : IRequestHandler<LessonGetAllQueryRequest, LessonGetAllQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LessonGetAllQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<LessonGetAllQueryResponse> Handle(LessonGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            //Todo: mapleme işlemi hatalı
            var lesson = _unitOfWork.LessonRepository.GetLessonsAll();
            var model = _mapper.Map<LessonGetAllQueryResponse>(lesson);
            return Task.FromResult(model);
        }
    }
}
