using Entities.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Reimbursement.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : BaseRestController<Payment, PaymentDTO, long>
{
    public PaymentController(IServiceManager service, IValidator<PaymentDTO>? validator = null)
        : base(service, validator)
    {
    }
}