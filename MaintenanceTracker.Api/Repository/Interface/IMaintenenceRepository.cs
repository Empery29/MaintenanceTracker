using MaintenanceTracker.Api.Data;

namespace MaintenanceTracker.Api.Repository.Interface
{
    public interface IMaintenenceRepository
    {
        Task<Maintenance> Create(Maintenance Model);

        Task<Maintenance> GetByTrackingnumber(string  trackingNumber);
        Task<Maintenance> GetById(int id);
        Task<IEnumerable<Maintenance>> GetAll();
        Task<Maintenance> Update(Maintenance Model);
        Task Delete(int id);


    }
}
