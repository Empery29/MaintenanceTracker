using MaintenanceTracker.Api.Controllers.Data;

namespace MaintenanceTracker.Api.Repository.Interface
{
    public interface IMaintenenceRepository
    {
        Task<Maintenance> Create(Maintenance Model);

        Task<Maintenance> GetByTrackingnumber(string  trackingNumber);
        Task<Maintenance> GetById(int id);
        Task<IEnumerable<Maintenance>> GetAllAsync();
        Task<Maintenance> Update(Maintenance Model);
        Task Delete(int id);


    }
}
