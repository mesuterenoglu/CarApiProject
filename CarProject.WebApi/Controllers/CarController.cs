
using CarProject.Application.DTOs;
using CarProject.Application.ServiceInterfaces;
using CarProject.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarProject.WebApi.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCar([FromBody] AddCarModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CarDto newCar = new CarDto();
                    newCar.Brand = model.Brand;
                    newCar.Color = model.Color;
                    await _carService.AddAsync(newCar);
                    return StatusCode(201, new { message = $"{model.Brand} brand, {model.Color} color car has been added" });
                }
                return BadRequest(new { message = "Model is invalid!" });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpGet("getactives")]
        public async Task<IActionResult> GetAllActive()
        {
            try
            {
                var cars = await _carService.GetAllActiveAsync();
                return Ok(cars);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cars = await _carService.GetAllAsync();
                return Ok(cars);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpGet("getinactives")]
        public async Task<IActionResult> GetAllInActive()
        {
            try
            {
                var cars = await _carService.GetAllInActiveAsync();
                return Ok(cars);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpPost("turnheadlights/{id}")]
        public async Task<IActionResult> TurnHeadlights(int id,[FromBody] TurnHeadlightModel model)
        {
            try
            {
                var result = await _carService.AnyAsync(id);
                if (result)
                {
                    if (model.Headlights)
                    {
                        await _carService.TurnOnHeadlights(id);
                        return Ok(new { message = "Car's headlights turned on!" });
                    }
                    else if (!model.Headlights)
                    {
                        await _carService.TurnOffHeadlights(id);
                        return Ok(new { message = "Car's headlights turned off!" });
                    }
                    else
                    {
                        return BadRequest(new { message = "There is something wrong with your request!" });
                    }
                }
                return BadRequest(new { message = "We couldn't find a car with this id!" });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpPut("delete/{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            try
            {
                var result = await _carService.AnyAsync(id);
                if (result)
                {
                    await _carService.DeleteAsync(id);
                    return Ok(new { message = "Car has been deleted!" });
                }
                return BadRequest(new { message = "We couldn't find a car with this id!" });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpDelete("removefromdb/{id}")]
        public async Task<IActionResult> RemoveFromDb(int id)
        {
            try
            {
                var result = await _carService.AnyAsync(id);
                if (result)
                {
                    await _carService.RemoveFromDbAsync(id);
                    return Ok(new { message = "Car has been removed from database!" });
                }
                return BadRequest(new { message = "We couldn't find a car with this id!" });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            try
            {
                var car = await _carService.GetbyIdAsync(id);
                if (car != null)
                {
                    return Ok(car);
                }
                return BadRequest(new { message = "We couldn't find a car with this id!" });


            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpGet("getbycolor/{color}")]
        public async Task<IActionResult> GetbyColor(string color)
        {
            try
            {
                var cars = await _carService.GetbyColorAsync(color.Trim());
                ;
                if (cars != null)
                {
                    return Ok(cars);
                }
                return BadRequest(new { message = "We couldn't find a car with this color!" });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] UpdateCarModel model)
        {
            try
            {
                var car = await _carService.GetbyIdAsync(id);
                if (car != null)
                {
                    if (ModelState.IsValid)
                    {
                        car.Brand = model.Brand;
                        car.Color = model.Color;
                        car.Headlights = model.Headlights;
                        await _carService.UpdateAsync(car);
                        return Ok(new { message = $"{model.Brand} brand, {model.Color} color car has been updated" });
                    }
                }
                return BadRequest(new { message = "We couldn't find a car with this id!" });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
