using AutoMapper;
using bidersGo.Application.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.LessonGetById
{
    public class LessonGetByIdQueryHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LessonGetByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;  
            _mapper = mapper;
        }
        public Task<LessonGetByIdQueryResponse> Handle(LessonGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var lesson = _unitOfWork.LessonRepository.GetById(request.Guid);
            var model = _mapper.Map<LessonGetByIdQueryResponse>(lesson);

            return Task<LessonGetByIdQueryResponse>.FromResult(model);
        }
    }
}
