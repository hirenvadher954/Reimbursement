using FluentValidation;
using Shared.WorkerReimbursements;

namespace Entities.Models.DataTransferObjects;

public class WorkerReimbursementDTOValidator : AbstractValidator<WorkerReimbursementDTO>
{
    public WorkerReimbursementDTOValidator()
    {
        RuleFor(x => x.ReceivedDt)
            .NotEmpty().WithMessage("Received date is required.");

        RuleFor(x => x.WRReferenceNum)
            .NotEmpty().WithMessage("WR Reference Number is required.")
            .MaximumLength(12).WithMessage("WR Reference Number cannot be longer than 12 characters.");
        
        // TODO: Add more validation rules
    }
}