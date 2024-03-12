using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Dtos
{
    public class GetByIdModelResponse
    {
        public Guid BrandId { get; set; } //1
        public string Name { get; set; } //"A6"

    }
}
