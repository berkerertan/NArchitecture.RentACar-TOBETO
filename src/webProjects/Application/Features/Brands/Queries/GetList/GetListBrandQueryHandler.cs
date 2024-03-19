using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetList
{
    public class GetListBrandQuery : IRequest<List<GetByIdBrandResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool BypassCache { get; }

        public string CacheKey => "brand-list";

        public TimeSpan? SlidingExpiration { get; }

    }
    public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, List<GetByIdBrandResponse>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<List<GetByIdBrandResponse>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
        {
            List<Brand> brands = await _brandRepository.GetAllAsync();
            var mappedBrandListModel = _mapper.Map<List<GetByIdBrandResponse>>(brands);
            return mappedBrandListModel;
        }
    }
}
