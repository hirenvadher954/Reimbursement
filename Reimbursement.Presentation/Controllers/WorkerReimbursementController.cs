using Entities.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.WorkerReimbursements;
using Shared.WorkerReimbursements;

namespace Reimbursement.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkerReimbursementController : ControllerBase
{
    private readonly IServiceManager _service;
    private readonly IValidator<WorkerReimbursementDTO>? _validator;

    public WorkerReimbursementController(IServiceManager service, IValidator<WorkerReimbursementDTO>? validator = null)
    {
        _service = service;
        _validator = validator;
    }

    [HttpPost("InsertForClaim")]
    public async Task<IActionResult> InsertForClaim([FromBody] WorkerReimbursementDTO dto)
    {
        if (_validator != null)
        {
            var validationResult = await _validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
        }

        var createdEntity = await _service.WorkerReimbursementService.CreateWorkerReimbursementAsync(dto);
        return Ok(createdEntity);
    }

    [HttpGet("GetAllForWorker/{ccn}")]
    public async Task<IActionResult> GetAllForWorker(string ccn)
    {
        var result = await _service.WorkerReimbursementService.FindByConditionsAsync(x => x.CustomerCareNumber == ccn);
        return Ok(result);
    }

    [HttpPut("UpdateWithCmsResponse")]
    public async Task<IActionResult> UpdateWithCmsResponse([FromBody] UpdateCmsResponseDTO dto)
    {
        var reimbursement =
            await _service.WorkerReimbursementService.UpdateWithCmsResponse(dto);

        return Ok(reimbursement);
    }
}