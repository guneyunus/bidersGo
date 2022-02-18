using AutoMapper;
using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using bidersGo.Application.Features.Queries.LessonGetById;

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
            var model = new LessonGetAllQueryResponse();
            
            foreach (var item in lesson)
            {
                model.LessonGetAll.Add(_mapper.Map<LessonGetByIdQueryResponse>(item));
            }


            return Task.FromResult(model);
        }
    }
}
