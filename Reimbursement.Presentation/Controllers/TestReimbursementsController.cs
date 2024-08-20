using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Reimbursement.Presentation.Controllers
{
    [Route("api/test-reimbursements")]
    //[Authorize]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    //[ResponseCache(CacheProfileName = "120SecondsDuration")]
    public class TestReimbursementsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public TestReimbursementsController(IServiceManager service) => _service = service;


        [HttpGet(Name = "GetReimbursements")]
        //[Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetReimbursements()
        {
            var companies = await _service.TestReimbursementService.GetAllTestReimbursementAsync(trackChanges: false);

            return Ok(companies);
        }

        [HttpGet("{id:guid}")]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
        [HttpCacheValidation(MustRevalidate = false)]
        public async Task<IActionResult> GetTestReimbursement(Guid id)
        {
            var reimbursement =
                await _service.TestReimbursementService.GetTestReimbursementAsync(id, trackChanges: false);
            return Ok(reimbursement);
        }
    }
}