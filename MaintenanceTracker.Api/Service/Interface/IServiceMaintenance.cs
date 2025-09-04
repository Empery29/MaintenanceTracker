using MaintenanceTracker.Api.DTO;

namespace MaintenanceTracker.Api.Service.Interface
{
    public interface IServiceMaintenance
    {
        Task<MaintenanceDto> Create(CreateMaintenanceRequestDto model);
        Task<GetMaintenanceByTrackingNumberDto> GetMaintenanceByTrackingNumber (string requestTrackingNumber);
        Task<MaintenanceDto> GetById(int id);
        Task<IEnumerable<MaintenanceDto>> GetAll();
        Task<MaintenanceDto> Update(int id, UpdateMaintenanceRequestDto model);
        Task Delete(int id);

    }
}
