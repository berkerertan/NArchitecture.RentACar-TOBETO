using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetList
{
    public class GetListCarQuery : IRequest<List<GetByIdCarResponse>>
    {

        public class GetListCarQueryHandler : IRequestHandler<GetListCarQuery, List<GetByIdCarResponse>>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;

            public GetListCarQueryHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }

            public async Task<List<GetByIdCarResponse>> Handle(GetListCarQuery request, CancellationToken cancellationToken)
            {
                List<Car> cars = await _carRepository.GetAllAsync();
                var mappedCarListModel = _mapper.Map<List<GetByIdCarResponse>>(cars);
                return mappedCarListModel;
            }
        }
    }
}
