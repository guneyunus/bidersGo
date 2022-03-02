using AutoMapper;
using bidersGo.Application.Features.Queries.ModeratorGetById;
using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.ModeratorGetAll
{
    public class ModeratorGetAllQueryHandler : IRequestHandler<ModeratorGetAllQueryRequest, ModeratorGetAllQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ModeratorGetAllQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<ModeratorGetAllQueryResponse> Handle(ModeratorGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            var moderator = _unitOfWork.ModeratorRepository.GetModeratorAll();
            var model = new ModeratorGetAllQueryResponse();
            foreach (var item in moderator)
            {
                model.GetModeratorAll.Add(_mapper.Map<ModeratorGetByIdQueryResponse>(item));
            }
            return Task.FromResult(model);

        }
    }
}
