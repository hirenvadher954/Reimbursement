using Entities.Models;
using Entities.Models.DataTransferObjects;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Reimbursement.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkerReimbursementController : BaseRestController<WorkerReimbursement, WorkerReimbursementDTO, long>
{
    private readonly IServiceManager _service;
    private readonly IValidator<WorkerReimbursementDTO>? _validator;
    public WorkerReimbursementController(IServiceManager service, IValidator<WorkerReimbursementDTO>? validator = null)
        : base(service, validator)
    {
        _service = service;
        _validator = validator;
    }
    
    public override async Task<IActionResult> AddEntity(WorkerReimbursementDTO dto)
    {
        if (_validator != null)
        {
            ValidationResult? validationResult = await _validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
        }

        WorkerReimbursementDTO createdEntity = await _service.WorkerReimbursementService.CreateWorkerReimbursementAsync(dto);
        return Ok(createdEntity);
    }

}