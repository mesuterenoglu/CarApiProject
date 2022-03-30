using CarProject.Application.DTOs;
using CarProject.Application.ServiceInterfaces;
using CarProject.WebApi.Models.Boat;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarProject.WebApi.Controllers
{
    [Route("api/boats")]
    [ApiController]
    public class BoatController : ControllerBase
    {
        private readonly IBoatService _boatService;

        public BoatController(IBoatService boatService)
        {
            _boatService = boatService;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddBoat([FromBody] AddBoatModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BoatDto newBoat = new BoatDto();
                    newBoat.Brand = model.Brand;
                    newBoat.Color = model.Color;
                    newBoat.Depth = model.Depth;
                    newBoat.Length = model.Length;
                    newBoat.Width = model.Width;
                    await _boatService.AddAsync(newBoat);
                    return StatusCode(201, new { message = $"{model.Brand} brand, {model.Color} color boat has been added" });
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
                var boats = await _boatService.GetAllActiveAsync();
                return Ok(boats);
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
                var boats = await _boatService.GetAllAsync();
                return Ok(boats);

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
                var boats = await _boatService.GetAllInActiveAsync();
                return Ok(boats);

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
                var result = await _boatService.AnyAsync(id);
                if (result)
                {
                    await _boatService.DeleteAsync(id);
                    return Ok(new { message = "Boat has been deleted!" });
                }
                return BadRequest(new { message = "We couldn't find a boat with this id!" });
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
                var result = await _boatService.AnyAsync(id);
                if (result)
                {
                    await _boatService.RemoveFromDbAsync(id);
                    return Ok(new { message = "Boat has been removed from database!" });
                }
                return BadRequest(new { message = "We couldn't find a boat with this id!" });
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
                var boat = await _boatService.GetbyIdAsync(id);
                if (boat != null)
                {
                    return Ok(boat);
                }
                return BadRequest(new { message = "We couldn't find a boat with this id!" });


            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpGet("getbycolor")]
        public async Task<IActionResult> GetbyColor([FromQuery] string color)
        {
            try
            {
                var boats = await _boatService.GetbyColorAsync(color.Trim());
                ;
                if (boats != null)
                {
                    return Ok(boats);
                }
                return BadRequest(new { message = "We couldn't find a boat with this color!" });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBoatModel model)
        {
            try
            {
                var boat = await _boatService.GetbyIdAsync(id);
                if (boat != null)
                {
                    if (ModelState.IsValid)
                    {
                        boat.Brand = model.Brand;
                        boat.Color = model.Color;
                        boat.Depth = model.Depth;
                        boat.Length = model.Length;
                        boat.Width = model.Width;

                        await _boatService.UpdateAsync(boat);
                        return Ok(new { message = $"{model.Brand} brand, {model.Color} color boat has been updated" });
                    }
                }
                return BadRequest(new { message = "We couldn't find a boat with this id!" });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
