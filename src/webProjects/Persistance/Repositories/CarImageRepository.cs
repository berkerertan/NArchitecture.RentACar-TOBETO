using Application.Services.Repositories;
using Core.Persistence.Repositories.EntityFramework;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class CarImageRepository : EfRepositoryBase<Brand, Guid, BaseDbContext>, ICarImageRepository
{
    public CarImageRepository(BaseDbContext context) : base(context)
    {
    }
}

