using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetById
{
    public class GetByIdModelQuery : IRequest<GetByIdModelResponse>
    {
        public Guid Id { get; set; }

        public class GetByIdModelQueryHandler : IRequestHandler<GetByIdModelQuery, GetByIdModelResponse>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetByIdModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdModelResponse> Handle(GetByIdModelQuery request, CancellationToken cancellationToken)
            {
                var car = await _modelRepository.GetAsync(p => p.Id == request.Id, include: x => x.Include(a => a.Brand));

                GetByIdModelResponse? response = _mapper.Map<GetByIdModelResponse>(car);
                return response;
            }
        }
    }
}
