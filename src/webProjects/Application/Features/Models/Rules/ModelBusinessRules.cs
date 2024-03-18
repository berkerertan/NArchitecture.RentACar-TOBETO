using Application.Features.Brands.Constants;
using Application.Features.Models.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Rules;

public class ModelBusinessRules : BaseBusinessRules
{
    private readonly IModelRepository _modelRepository;

    public ModelBusinessRules(IModelRepository modelRepository)
    {
        _modelRepository = modelRepository;
    }

    public void ModelIdShouldExistWhenSelected(Model? model)
    {
        if (model == null)
            throw new BusinessException(ModelsMessages.ModelNotExists);
    }

    public async Task ModelNameCanNotBeDuplicatedWhenInserted(string name)
    {
        Model? result = await _modelRepository.GetAsync(x => x.Name.ToLower() == name.ToLower());
        if (result != null)
            throw new BusinessException(ModelsMessages.ModelNameExists);
    }

    public async Task ModelNameCanNotBeDuplicatedWhenUpdated(Model model)
    {
        Model? result = await _modelRepository.GetAsync(x => x.Id != model.Id && x.Name.ToLower() == model.Name.ToLower());
        if (result != null)
            throw new BusinessException(ModelsMessages.ModelNameExists);
    }
}
