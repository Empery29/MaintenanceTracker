using MaintenanceTracker.Api.DTO;
using MaintenanceTracker.Api.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private readonly IServiceMaintenance _serviceMaintenance;
        public MaintenanceController(IServiceMaintenance serviceMaintenance)
        {
            _serviceMaintenance = serviceMaintenance;
        }

        [HttpGet("GetByTrackingNumber/{trackingNumber}")]
        public async Task<IActionResult> GetByTrackingNumber(string trackingNumber)
        {
            var maintenance = await _serviceMaintenance.GetMaintenanceByTrackingNumber(trackingNumber);
            if (maintenance == null)
            {
                return NotFound();
            }
            return Ok(maintenance);

        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var maintenance = await _serviceMaintenance.GetAll();
            return Ok(maintenance);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateNew(CreateMaintenanceRequestDto model)
        {
            var maintenance = await _serviceMaintenance.Create(model);
            return Ok(maintenance);

        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetMaintenanceById(int id)
        {
            var maintenance = await _serviceMaintenance.GetById(id);
            if (maintenance == null)
            {
                return NotFound();
            }
            return Ok(maintenance);

        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceMaintenance.Delete(id);
            return NoContent();


        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMaintenanceRequestDto model)
        {
            var maintenance = await _serviceMaintenance.Update(id, model);
                return Ok(maintenance);
        }
    }
}
