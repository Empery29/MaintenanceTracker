using MaintenanceTracker.Api.Controllers.Data;
using MaintenanceTracker.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace MaintenanceTracker.Api.Repository.Implementation
{
    public class MaintenanceRepository : IMaintenenceRepository
    {
        private readonly MaintenanceDbContext _db;
        public MaintenanceRepository(MaintenanceDbContext db)
        {
            _db = db;
        }
        public async Task<Maintenance> Create(Maintenance Model)
        {
            var createdMaintenance = await _db.Maintenances.AddAsync(Model);
            await _db.SaveChangesAsync();
            return createdMaintenance.Entity;
        }

        public async Task Delete(int id)
        {
            _db.Maintenances.Remove(await GetById(id));
            await _db.SaveChangesAsync();
        }

     

        public async Task<IEnumerable<Maintenance>> GetAllAsync()
        {
            return await _db.Maintenances.ToListAsync();
        }

        public async Task<Maintenance> GetById(int id)
        {
           var maintenace = await _db.Maintenances.FirstOrDefaultAsync(m => m.Id == id);
            if (maintenace == null)
            {
                throw new Exception("Maintenance not found");
            }
            return maintenace;
        }

        public async Task<Maintenance> GetByTrackingnumber(string trackingNumber)
        {
            var maintenance = await _db.Maintenances.FirstOrDefaultAsync(o => o.RequestTrackingNumber == trackingNumber);
            if (maintenance == null)
            {
                return null;
            }
            return maintenance;

        }

        public async Task<Maintenance> Update(Maintenance Model)
        {
            var maintenance = _db.Maintenances.Update(Model);
            await _db.SaveChangesAsync();
            return maintenance.Entity;
        }
    }
}
