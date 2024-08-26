using Entities.Models;
using Entities.Models.DataTransferObjects;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Reimbursement.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkerReimbursementController : BaseRestController<WorkerReimbursement, WorkerReimbursementDTO, long>
{
    public WorkerReimbursementController(IServiceManager service, IValidator<WorkerReimbursementDTO>? validator = null)
        : base(service, validator)
    {
    }
}