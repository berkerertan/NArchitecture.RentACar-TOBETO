using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Utilities.Helpers;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CarImageService;

public class CarImageManager : ICarImageService
{
    private readonly ICarImageRepository _carImageRepository;
    private readonly CarImageBusinessRules _rules;

    public CarImageManager(ICarImageRepository carImageRepository, CarImageBusinessRules rules)
    {
        _carImageRepository = carImageRepository;
        _rules = rules;
    }

    public async Task Add(IFormFile file, CarImage carImage)
    {
        await _rules.CheckIfCarImageNull(carImage.CarId);
        await _rules.CheckIfCarImageFormat(file);
        await _rules.CheckIfImageLimit(carImage.CarId);
        CarImage carImage1=new CarImage()
        {
            CarId = carImage.CarId,
            ImagePath =request.ImagePath,
        }
        carImage.ImagePath = FileHelper.Add(file, "CarImages");
        await _carImageRepository.AddAsync(carImage);
    }

    public async Task Delete(CarImage carImage)
    {
        await _rules.CarImageIdShouldExistWhenSelected(carImage.CarId);
        var path = Path.Combine(Directory.GetCurrentDirectory(), $@"wwwroot") + _carImageRepository.GetAsync
            (c => c.Id == carImage.Id).Result.ImagePath;
        var result = FileHelper.Delete(path);
        await _carImageRepository.DeleteAsync(carImage);
    }

    public async Task<CarImage> Get(Guid id)
    {
        return await _carImageRepository.GetAsync(c => c.Id == id);
    }

    public async Task<List<CarImage>> GetImagesByCarId(Guid id)
    {
        await _rules.CarImageIdShouldExistWhenSelected(id);
        return await _rules.CheckIfCarImageNull(id);


    }

    public async Task<List<CarImage>> GetList()
    {
        return await _carImageRepository.GetAllAsync(include: c => c.Include(c => c.Car));
    }

    public async Task Update(IFormFile file, CarImage carImage)
    {
        await _rules.CheckIfCarImageFormat(file);
        await _rules.CheckIfCarImageNull(carImage.CarId);
        var path = Path.Combine(Directory.GetCurrentDirectory(), $@"wwwroot") + _carImageRepository.GetAsync
           (c => c.Id == carImage.Id).Result.ImagePath;
        carImage.ImagePath = FileHelper.Update(path, file, "CarImages");
        await _carImageRepository.UpdateAsync(carImage);
    }
}
