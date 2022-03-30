using CarProject.Application.DTOs;
using CarProject.Application.ServiceInterfaces;
using CarProject.WebApi.Models.Bus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarProject.WebApi.Controllers
{
    [Route("api/buses")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddBus([FromBody] AddBusModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BusDto newBus = new BusDto();
                    newBus.Brand = model.Brand;
                    newBus.Color = model.Color;
                    newBus.Capacity = model.Capacity;
                    await _busService.AddAsync(newBus);
                    return StatusCode(201, new { message = $"{model.Brand} brand, {model.Color} color bus has been added" });
                }
                return BadRequest(new { message ="Model is invalid!"});
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
                var buses = await _busService.GetAllActiveAsync();
                return Ok(buses);
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
                var buses = await _busService.GetAllAsync();
                return Ok(buses);

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
                var buses = await _busService.GetAllInActiveAsync();
                return Ok(buses);

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
                var result = await _busService.AnyAsync(id);
                if (result)
                {
                    await _busService.DeleteAsync(id);
                    return Ok(new { message = "Bus has been deleted!" });
                }
                return BadRequest(new { message = "We couldn't find a bus with this id!" });
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
                var result = await _busService.AnyAsync(id);
                if (result)
                {
                    await _busService.RemoveFromDbAsync(id);
                    return Ok(new { message = "Bus has been removed from database!" });
                }
                return BadRequest(new { message = "We couldn't find a bus with this id!" });
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
                var bus = await _busService.GetbyIdAsync(id);
                if (bus != null)
                {
                    return Ok(bus);
                }
                return BadRequest(new { message = "We couldn't find a bus with this id!" });


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
                var buses = await _busService.GetbyColorAsync(color.Trim());
                ;
                if (buses != null)
                {
                    return Ok(buses);
                }
                return BadRequest(new { message = "We couldn't find a bus with this color!" });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBusModel model)
        {
            try
            {
                var bus = await _busService.GetbyIdAsync(id);
                if (bus != null)
                {
                    if (ModelState.IsValid)
                    {
                        bus.Brand = model.Brand;
                        bus.Color = model.Color;
                        bus.Capacity = model.Capacity;
                        await _busService.UpdateAsync(bus);
                        return Ok(new { message = $"{model.Brand} brand, {model.Color} color bus has been updated" });
                    }
                }
                return BadRequest(new { message = "We couldn't find a bus with this id!" });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

    }
}
