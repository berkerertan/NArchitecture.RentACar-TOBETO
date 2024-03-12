using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetList
{
    public class GetListModelQuery : IRequest<List<GetByIdModelResponse>>
    {

        public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, List<GetByIdModelResponse>>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<List<GetByIdModelResponse>> Handle(GetListModelQuery request, CancellationToken cancellationToken)
            {
                List<Model> models = await _modelRepository.GetAllAsync(include: x => x.Include(a => a.Brand));
                List<GetByIdModelResponse> responses = _mapper.Map<List<GetByIdModelResponse>>(models);
                return responses;
            }
        }
    }
}
