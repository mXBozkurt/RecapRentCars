using Core.Utilities.Results;
using Entities.DTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetById(int id);
        IDataResult<List<Car>> DailyPrice(decimal min,decimal max);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);

        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
    }
}
