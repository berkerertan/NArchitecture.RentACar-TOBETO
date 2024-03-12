using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Commands.Update;

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdatedCarResponse>
{
    private ICarRepository _carRepository { get; }
    private IMapper _mapper { get; }

    public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<UpdatedCarResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        Car? car = await _carRepository.GetAsync(p => p.Id == request.Id);

        _mapper.Map(request, car);
        Car updatedCar = await _carRepository.UpdateAsync(car);
        UpdatedCarResponse updatedCarDto = _mapper.Map<UpdatedCarResponse>(updatedCar);
        return updatedCarDto;
    }
}
