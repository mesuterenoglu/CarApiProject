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
    public class BoatService : IBoatService
    {
        private readonly IBoatRepository _boatRepository;
        private readonly IMapper _mapper;

        public BoatService(IBoatRepository boatRepository,IMapper mapper)
        {
            _boatRepository = boatRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(BoatDto entity)
        {
            try
            {
                var boat = _mapper.Map<Boat>(entity);
                await _boatRepository.AddAsync(boat);
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
                return await _boatRepository.AnyAsync(x => x.Id == id);
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
                await _boatRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<BoatDto>> GetAllActiveAsync()
        {
            try
            {
                var boats = await _boatRepository.GetAllActiveAsync();
                var dtos = _mapper.Map<List<BoatDto>>(boats);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<BoatDto>> GetAllAsync()
        {
            try
            {
                var boats = await _boatRepository.GetAllAsync();
                var dtos = _mapper.Map<List<BoatDto>>(boats);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<BoatDto>> GetAllInActiveAsync()
        {
            try
            {
                var boats = await _boatRepository.GetAllInActiveAsync();
                var dtos = _mapper.Map<List<BoatDto>>(boats);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<BoatDto>> GetbyColorAsync(string color)
        {
            try
            {
                var boats = await _boatRepository.GetbyColorAsync(color);
                var dtos = _mapper.Map<List<BoatDto>>(boats);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<BoatDto> GetbyIdAsync(int id)
        {
            try
            {
                var boat = await _boatRepository.GetbyIdAsync(id);
                var dto = _mapper.Map<BoatDto>(boat);
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
                await _boatRepository.RemoveFromDbAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public async Task UpdateAsync(BoatDto entity)
        {
            try
            {
                var boat = await _boatRepository.GetbyIdAsync(entity.Id);

                boat.Brand = entity.Brand;
                boat.Color = entity.Color;
                boat.Depth = entity.Depth;
                boat.Length = entity.Length;
                boat.Width = entity.Width;
                await _boatRepository.UpdateAsync(boat);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
