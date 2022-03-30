using AutoMapper;
using CarProject.Application.DTOs;
using CarProject.Application.ServiceInterfaces;
using CarProject.Domain.Entities;
using CarProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarProject.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository,IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(CarDto entity)
        {
            try
            {
                var car = _mapper.Map<Car>(entity);
                await _carRepository.AddAsync(car);
            }
            catch (Exception ex)
            {
                throw new  InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> AnyAsync(int id)
        {
            try
            {
                return await _carRepository.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new  InvalidOperationException(ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _carRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new  InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<CarDto>> GetAllActiveAsync()
        {
            try
            {
                var cars = await _carRepository.GetAllActiveAsync();
                var dtos = _mapper.Map<List<CarDto>>(cars);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new  InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<CarDto>> GetAllAsync()
        {
            try
            {
                var cars = await _carRepository.GetAllAsync();
                var dtos = _mapper.Map<List<CarDto>>(cars);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new  InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<CarDto>> GetAllInActiveAsync()
        {
            try
            {
                var cars = await _carRepository.GetAllInActiveAsync();
                var dtos = _mapper.Map<List<CarDto>>(cars);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new  InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<CarDto>> GetbyColorAsync(string color)
        {
            try
            {
                var cars = await _carRepository.GetbyColorAsync(color);
                var dtos = _mapper.Map<List<CarDto>>(cars);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new  InvalidOperationException(ex.Message);
            }
        }

        public async Task<CarDto> GetbyIdAsync(int id)
        {
            try
            {
                var car = await _carRepository.GetbyIdAsync(id);
                var dto = _mapper.Map<CarDto>(car);
                return dto;
            }
            catch (Exception ex)
            {
                throw new  InvalidOperationException(ex.Message);
            }
        }

        public async Task RemoveFromDbAsync(int id)
        {
            try
            {
                await _carRepository.RemoveFromDbAsync(id);
            }
            catch (Exception ex)
            {
                throw new  InvalidOperationException(ex.Message);
            }
        }

        public async Task TurnOffHeadlights(int id)
        {
            try
            {
                await _carRepository.TurnOffHeadlights(id);
            }
            catch (Exception ex)
            {
                throw new  InvalidOperationException(ex.Message);
            }
        }

        public async Task TurnOnHeadlights(int id)
        {
            try
            {
                await _carRepository.TurnOnHeadlights(id);
            }
            catch (Exception ex)
            {
                throw new  InvalidOperationException(ex.Message);
            }
        }

        public async Task UpdateAsync(CarDto entity)
        {
            try
            {
                var car = await _carRepository.GetbyIdAsync(entity.Id);

                car.Brand = entity.Brand;
                car.Color = entity.Color;
                car.Wheels = entity.Wheels;
                await _carRepository.UpdateAsync(car);

            }
            catch (Exception ex)
            {
                throw new  InvalidOperationException(ex.Message);
            }
        }
    }
}
