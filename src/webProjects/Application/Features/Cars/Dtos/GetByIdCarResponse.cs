﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Dtos
{
    public class GetByIdCarResponse
    {
        public Guid ModelId { get; set; }
        public int ModelYear { get; set; }
        public string Plate { get; set; }
        public int State { get; set; }  // 1- Available 2- Rented 3-Under Maitenance
        public double DailyPrice { get; set; }
    }
}
