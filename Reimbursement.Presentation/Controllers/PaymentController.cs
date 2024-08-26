using Entities.Models;
using Entities.Models.DataTransferObjects;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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