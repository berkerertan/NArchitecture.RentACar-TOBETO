﻿using Application.Features.Brands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Update
{
    public class UpdateBrandCommand : IRequest<UpdatedBrandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool BypassCache { get; }
        public string CacheKey => "brand-list";
    }
}
