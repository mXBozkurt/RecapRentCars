using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImagesDal;

        public CarImageManager(ICarImageDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(CarImage carImages)
        {
            var result = BusinessRules.Run(CheckCountOfCarImages(carImages.Id));
            if (result != null)
            {
                return result;
            }
            _carImagesDal.Add(carImages);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImages)
        {
            _carImagesDal.Delete(carImages);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImagesDal.Get(p=>p.Id==id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(), Messages.CarImageListed);
        }

        public IDataResult<CarImage> GetByID(int ID)
        {
            return new SuccessDataResult<CarImage>(_carImagesDal.Get(c => c.Id == ID), Messages.CarImageListed);
        }

        public IDataResult<List<string>> GetImagesByCarID(int id)
        {
            List<string> list = new List<string>();
            var result = _carImagesDal.GetAll(c => c.Id == id);
            if (result.Count == 0)
            {
                return new SuccessDataResult<List<string>>(new List<string> { @"CarImages\default.jpg" }, Messages.CarImageListed);
            }
            foreach (var item in result)
            {
                list.Add(item.ImagePath);
            }
            return new SuccessDataResult<List<string>>(list, Messages.CarImageListed);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(CarImage carImages)
        {
            _carImagesDal.Update(carImages);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckCountOfCarImages(int carID)
        {
            var result = _carImagesDal.GetAll(c => c.Id == carID).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageCountError);
            }
            return new SuccessResult();
        }
    }
}
