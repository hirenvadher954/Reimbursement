using Entities.Models;
using Entities.Models.DataTransferObjects;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Reimbursement.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentItemController : BaseRestController<PaymentItem, PaymentItemDTO, long>
{
    public PaymentItemController(IServiceManager service, IValidator<PaymentItemDTO>? validator = null)
        : base(service, validator)
    {
    }
}