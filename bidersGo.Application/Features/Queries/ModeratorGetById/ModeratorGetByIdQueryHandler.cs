using AutoMapper;
using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.ModeratorGetById
{
    public class ModeratorGetByIdQueryHandler:IRequestHandler<ModeratorGetByIdQueryRequest,ModeratorGetByIdQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ModeratorGetByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ModeratorGetByIdQueryResponse> Handle(ModeratorGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var moderator = _unitOfWork.ModeratorRepository.GetModeratorById(request.Guid);
            ModeratorGetByIdQueryResponse model=_mapper.Map<ModeratorGetByIdQueryResponse>(moderator);

            return Task<ModeratorGetByIdQueryResponse>.FromResult(model);
        }
    }
}
