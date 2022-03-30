

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
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;
        private readonly IMapper _mapper;

        public BusService(IBusRepository busRepository, IMapper mapper)
        {
            _busRepository = busRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(BusDto entity)
        {
            try
            {
                var bus = _mapper.Map<Bus>(entity);
                await _busRepository.AddAsync(bus);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> AnyAsync(int id)
        {
            try
            {
                return await _busRepository.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _busRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<BusDto>> GetAllActiveAsync()
        {
            try
            {
                var buses = await _busRepository.GetAllActiveAsync();
                var dtos = _mapper.Map<List<BusDto>>(buses);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<BusDto>> GetAllAsync()
        {
            try
            {
                var buses = await _busRepository.GetAllAsync();
                var dtos = _mapper.Map<List<BusDto>>(buses);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<BusDto>> GetAllInActiveAsync()
        {
            try
            {
                var buses = await _busRepository.GetAllInActiveAsync();
                var dtos = _mapper.Map<List<BusDto>>(buses);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<BusDto>> GetbyColorAsync(string color)
        {
            try
            {
                var buses = await _busRepository.GetbyColorAsync(color);
                var dtos = _mapper.Map<List<BusDto>>(buses);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<BusDto> GetbyIdAsync(int id)
        {
            try
            {
                var bus = await _busRepository.GetbyIdAsync(id);
                var dto = _mapper.Map<BusDto>(bus);
                return dto;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task RemoveFromDbAsync(int id)
        {
            try
            {
                await _busRepository.RemoveFromDbAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public async Task UpdateAsync(BusDto entity)
        {
            try
            {
                var bus = await _busRepository.GetbyIdAsync(entity.Id);

                bus.Brand = entity.Brand;
                bus.Capacity = entity.Capacity;
                bus.Color = entity.Color;

                await _busRepository.UpdateAsync(bus);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
