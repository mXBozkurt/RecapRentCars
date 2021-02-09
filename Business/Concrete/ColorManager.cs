using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public Color GetById(int colorId)
        {
            throw new NotImplementedException();
        }

        public List<Color> GettAllColors()
        {
            return _colorDal.GetAll();
        }
    }
}
