using MeroBriksha.Data.Interfaces;
using MeroBriksha.Services.DTOs.SelectPlantDTOs;
using MeroBriksha.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Services
{
    public class SelectPlantService : ISelectPlantService
    {
        private readonly ISelectPlantRepository _repository;

        public SelectPlantService(ISelectPlantRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SelectPlantResponse>> GetAllAsync()
        {
            var selectPlants = await _repository.GetAllAsync();

            return selectPlants.Select(x => new SelectPlantResponse
            {
                PlantID = x.PlantID,
                TreeAssignmentID = x.TreeAssignmentID
            }).ToList();
        }

        public async Task<SelectPlantResponse?> GetByPlantIdAsync(string plantId)
        {
            var selectPlant = await _repository.GetByPlantIdAsync(plantId);

            if (selectPlant == null)
                return null;

            return new SelectPlantResponse
            {
                PlantID = selectPlant.PlantID,
                TreeAssignmentID = selectPlant.TreeAssignmentID
            };
        }

        public async Task<SelectPlantResponse?> GetByTreeAssignmentIdAsync(string treeAssignmentId)
        {
            var selectPlant = await _repository.GetByTreeAssignmentIdAsync(treeAssignmentId);

            if (selectPlant == null)
                return null;

            return new SelectPlantResponse
            {
                PlantID = selectPlant.PlantID,
                TreeAssignmentID = selectPlant.TreeAssignmentID
            };
        }
    }
}

