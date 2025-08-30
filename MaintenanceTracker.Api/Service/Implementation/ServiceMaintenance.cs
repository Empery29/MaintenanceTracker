using MaintenanceTracker.Api.Data;
using MaintenanceTracker.Api.DTO;
using MaintenanceTracker.Api.Enums;
using MaintenanceTracker.Api.Repository.Interface;
using MaintenanceTracker.Api.Service.Interface;
using System.Threading.Tasks;

namespace MaintenanceTracker.Api.Service.Implementation
{
    public class ServiceMaintenance : IServiceMaintenance
    {
        private readonly IMaintenenceRepository _repo;
        public ServiceMaintenance(IMaintenenceRepository repo)
        {
            _repo = repo;
        }
        public async Task<MaintenanceDto> Create(CreateMaintenanceRequestDto model)
        {
            var maintenance = new Maintenance
            {
                Title = model.Title,
                Description = model.Description,
                Category = (Category)model.Category,
                Priority = (Priority)model.Priority,
                Status = (Status)model.Status,
                RequestTrackingNumber = PrivateMethod.GenerateRequestTrackingNumber()
            };
           var createdModel = await _repo.Create(maintenance);
            var maintenanceDto = new MaintenanceDto
            {
                Id = createdModel.Id,
                Title = createdModel.Title,
                Description = createdModel.Description,
                Category = createdModel.Category,
                Priority = createdModel.Priority,
                Status = createdModel.Status,
                CreatedAt = createdModel.CreatedAt,
                UpdatedAt = createdModel.UpdatedAt,
                RequestTrackingNumber = createdModel.RequestTrackingNumber
            };
            return maintenanceDto;
        }

       
        public async Task Delete(int id)
        {
           await _repo.Delete(id);

        }

        public async Task<IEnumerable<MaintenanceDto>> GetAll()
        {
            var maintnances = await _repo.GetAll();
            return maintnances.Select(m => new MaintenanceDto
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                Category = m.Category,
                Priority = m.Priority,
                Status = m.Status,
                CreatedAt = m.CreatedAt,
                UpdatedAt = m.UpdatedAt,
                RequestTrackingNumber = m.RequestTrackingNumber
            });
        }

        public async Task<MaintenanceDto> GetById(int id)
        {
            var maintenance = await _repo.GetById(id);
            return new MaintenanceDto
            {
                Id = maintenance.Id,
                Title = maintenance.Title,
                Description = maintenance.Description,
                Category = maintenance.Category,
                Priority = maintenance.Priority,
                Status = maintenance.Status,
                CreatedAt = maintenance.CreatedAt,
                UpdatedAt = maintenance.UpdatedAt,
                RequestTrackingNumber = maintenance.RequestTrackingNumber
            };
        }

        public async Task<GetMaintenanceByTrackingNumberDto> GetMaintenanceByTrackingNumber(string requestTrackingNumber)
        {
            var maintenance = await _repo.GetByTrackingnumber(requestTrackingNumber);
            return new GetMaintenanceByTrackingNumberDto
            {
                Id = maintenance.Id,
                Title = maintenance.Title,
                Description = maintenance.Description,
                Category = maintenance.Category,
                Priority = maintenance.Priority,
                Status = maintenance.Status,
                CreatedAt = maintenance.CreatedAt,
                UpdatedAt = maintenance.UpdatedAt,
                RequestTrackingNumber = maintenance.RequestTrackingNumber

            };
        }

        public async Task<MaintenanceDto> Update(int id, UpdateMaintenanceRequestDto model)
        {
           var existingMaintenance = await _repo.GetById(id);
            existingMaintenance.Title = !string.IsNullOrEmpty(model.Title) && model.Title != existingMaintenance.Title ? model.Title : existingMaintenance.Title;
            existingMaintenance.Description = !string.IsNullOrEmpty(model.Description) && model.Description != existingMaintenance.Description ? model.Description : existingMaintenance.Description;
            existingMaintenance.Category = model.Category != null && model.Category != existingMaintenance.Category ? model.Category.Value : existingMaintenance.Category;
            existingMaintenance.Priority = model.Priority != null && model.Priority != existingMaintenance.Priority ? model.Priority.Value : existingMaintenance.Priority;
            existingMaintenance.Status = model.Status != null && model.Status != existingMaintenance.Status ? model.Status.Value : existingMaintenance.Status;


            var updatedMaintenance = await _repo.Update(existingMaintenance);
         
            return new MaintenanceDto
            {
                Title = updatedMaintenance.Title,
                Description = updatedMaintenance.Description,
                Category = updatedMaintenance.Category,
                Priority = updatedMaintenance.Priority,
                Status = updatedMaintenance.Status,
                Id = updatedMaintenance.Id,
                RequestTrackingNumber = updatedMaintenance.RequestTrackingNumber
            };
        }

    }
}
