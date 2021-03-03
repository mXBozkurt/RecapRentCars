using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetImagesByCarID(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByImageByCarId(int id)
        {
            var result = _carImageService.GetImagesByCarID(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] int carId, [FromForm] IFormFile file)
        {
            if (Path.GetExtension(file.FileName) != ".png" && Path.GetExtension(file.FileName) != ".jpg" && Path.GetExtension(file.FileName) != ".jpeg")
            {
                return BadRequest("Sadece Resim Dosyası Yükleyebilirsiniz...");
            }
            CarImage carImage = new CarImage();
            carImage.CarId = carId;
            carImage.ImagePath = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            carImage.Date = DateTime.Now;
            var result = _carImageService.Add(carImage);
            if (result.Success)
            {
                FileStream fileStream = System.IO.File.Create(Path.Combine(@"CarImages\" + carImage.ImagePath));
                file.CopyTo(fileStream);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var data = _carImageService.Get(id);
            var result = _carImageService.Delete(data.Data);
            if (result.Success)
            {
                System.IO.File.Delete(Path.Combine(@"CarImages\" + data.Data.ImagePath));
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] int id, [FromForm] int carId, [FromForm] IFormFile file)
        {
            if (Path.GetExtension(file.FileName) != ".png" && Path.GetExtension(file.FileName) != ".jpg" && Path.GetExtension(file.FileName) != ".jpeg")
            {
                return BadRequest("Sadece Resim Dosyası Yükleyebilirsiniz...");
            }
            var data = _carImageService.Get(id);
            data.Data.CarId = carId;
            System.IO.File.Delete(Path.Combine(@"CarImages\"+data.Data.ImagePath));
            data.Data.ImagePath = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            data.Data.Date = DateTime.Now;
            var result = _carImageService.Update(data.Data);
            if (result.Success)
            {
                FileStream fileStream = System.IO.File.Create(Path.Combine(@"CarImages\" + data.Data.ImagePath));
                file.CopyTo(fileStream);
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
