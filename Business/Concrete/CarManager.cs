using Business.Abstract;
using DataAccess.Abstract;
using Entities.CarDetailsDto;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IEnumerable<object> GetCars()
        {
            throw new NotImplementedException();
        }

        public List<Car> DailyPrice(decimal min,decimal max)
        {
            return _carDal.GetAll(p=>p.DailyPrice>=min&&p.DailyPrice<=max);
        }

        public List<Car> GetById(int id)
        {
            return _carDal.GetAll(p=>p.Id==id);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
