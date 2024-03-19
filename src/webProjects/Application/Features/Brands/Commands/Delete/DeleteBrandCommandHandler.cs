using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Delete
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _rules;

        public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules rules)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brand = await _brandRepository.GetAsync(x => x.Id == request.Id);
            _rules.BrandIdShouldExistWhenSelected(brand);
            _mapper.Map(request, brand);
            Brand deletedBrand = await _brandRepository.DeleteAsync(brand);
            DeletedBrandResponse? response = _mapper.Map<DeletedBrandResponse>(deletedBrand);
            return response;
        }
    }
}
