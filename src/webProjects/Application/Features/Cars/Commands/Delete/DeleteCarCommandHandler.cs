using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Commands.Delete;

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeletedCarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<DeletedCarResponse> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        Car? car = await _carRepository.GetAsync(p => p.Id == request.Id);

        Car deletedCar = await _carRepository.DeleteAsync(car);
        DeletedCarResponse deletedCarDto = _mapper.Map<DeletedCarResponse>(deletedCar);
        return deletedCarDto;
    }
}
