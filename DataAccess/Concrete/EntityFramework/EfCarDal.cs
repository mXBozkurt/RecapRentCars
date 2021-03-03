using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        //NUGET
        public List<CarDetailsDto> GetCarDetails()

        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from c in context.Cars
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new CarDetailsDto
                             {
                                 CarId=c.Id,
                                 BrandName=b.BrandName,
                                 ColorName=cl.ColorName,
                                 Description=c.Description,
                                 DailyPrice=c.DailyPrice,
                                 ModelYear=c.ModelYear
                             };
                return result.ToList();
            }
        }
    }
}
