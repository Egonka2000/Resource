using Microsoft.AspNetCore.Mvc;
using Resources.Business;
using Resources.API.DTO;

namespace Resources.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private IService _service;

        public ResourceController(IService service)
        {
            this._service = service;
        }

        [HttpPost]
        public IActionResult UseResource()
        {
            var (name, usage) = _service.UseResource();
            ResourceUsageResult usageResult = new ResourceUsageResult(name, usage);
            return Ok(usageResult);
        }
    }
}
