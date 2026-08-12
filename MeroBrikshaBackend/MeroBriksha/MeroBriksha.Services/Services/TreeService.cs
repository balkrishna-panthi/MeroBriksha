using MeroBriksha.Core.Entities;
using MeroBriksha.Core.ReadModels;
using MeroBriksha.Data.Interfaces;
using MeroBriksha.Services.DTOs.TreeDTOs;
using MeroBriksha.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Services
{
    public class TreeService : ITreeService
    {
        ITreeRepository _treeRepository;
        public TreeService(ITreeRepository treeRepository)
        {
            _treeRepository = treeRepository;
        }
        public async Task<CreateTreeResponse?> CreateAsync(CreateTreeRequest request)
        {
            var treeToCreate = new Tree
            {
                ID = Guid.NewGuid().ToString(),
                TREEASSIGNMENTID = request.TreeAssignmentId,
                PLANTID = request.PlantId,
                ADDRESS = request.Address,
                LOCATIONLINK = request.LocationLink,
                LATITUDE = request.Latitude,
                LONGITUDE = request.Longitude,
                TRACKINGCODE = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                PLANTEDDATE = request.PlantedDate
            };
            var createdTree = await _treeRepository.CreateAsync(treeToCreate);
            return new CreateTreeResponse
            {

                IsSuccess = createdTree != null
            };
        }

        public async Task<List<TreeDetails>> GetAllAsync()
        {
            var tree = await _treeRepository.GetAllAsync();
            return tree.Select(tree => new TreeDetails
            {
                Id = tree.Id,
                TreeAssignmentId = tree.TreeAssignmentId,
                Name = tree.Name,
                Description = tree.Description,
                Species = tree.Species,
                DonorName = tree.DonorName
            }).ToList();
        }

        public async Task<TreeDetails?> GetByTrackingIdAsync(string id)
        {
            var tree = await _treeRepository.GetByTrackingIdAsync(id);
            if (tree == null) return null;

            return new TreeDetails
            {
                Id = tree.Id,
                TreeAssignmentId = tree.TreeAssignmentId,
                Name = tree.Name,
                Description = tree.Description,
                Species = tree.Species,
                DonorName = tree.DonorName
            };
        }

        public async Task<TreeDetails?> GetByTreeIdAsync(string id)
        {
            var tree = await _treeRepository.GetByTreeIdAsync(id);
            if (tree == null) return null;

            return new TreeDetails
            {
                Id = tree.Id,
                TreeAssignmentId = tree.TreeAssignmentId,
                Name = tree.Name,
                Description = tree.Description,
                Species = tree.Species,
                DonorName = tree.DonorName
            };
        }
    }
}
