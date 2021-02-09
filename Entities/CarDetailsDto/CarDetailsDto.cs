using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.CarDetailsDto
{
    public class CarDetailsDto:ICarDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public int DailyPrice { get; set; }


    }
}
