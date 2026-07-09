using MeroBriksha.Core.Entities;
using MeroBriksha.Data.Interfaces;
using MeroBriksha.Services.DTOs.LocationSelectionDTOs;
using MeroBriksha.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ITreeAssignmentRepository _treeAssignmentRepository;

        public LocationService(ILocationRepository locationRepository, ITreeAssignmentRepository treeAssignmentRepository)
        {
            _locationRepository = locationRepository;
            _treeAssignmentRepository = treeAssignmentRepository;
        }
        public async Task<string> AssignLocationAsync(string treeAssignmentId, AssignLocationRequest location)
        {
            var treeAssignmentExists = await _treeAssignmentRepository.GetByIdAsync(treeAssignmentId);
            if (treeAssignmentExists == null) 
            {
                throw new ArgumentException("Tree assignment not found");
            }

            Location newLocation = new Location
            {
                ID = Guid.NewGuid().ToString(),
                LATITUDE = location.Latitude,
                LONGITUDE = location.Longitude,
                ADDRESS = location.Address,
                LOCATIONLINK = location.LocationLink
            };

            return await _locationRepository.AssignLocationAsync(treeAssignmentId, newLocation);
        }
    }
}
