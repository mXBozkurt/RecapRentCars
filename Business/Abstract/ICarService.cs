using Entities.CarDetailsDto;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetById(int id);
        List<Car> DailyPrice(decimal min,decimal max);
        List<CarDetailsDto> GetCarDetails();
    }
}
