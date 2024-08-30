using FluentValidation;
using Shared.WorkerReimbursements;

namespace Entities.Models.DataTransferObjects;

public class WorkerReimbursementDTOValidator : AbstractValidator<WorkerReimbursementDTO>
{
    public WorkerReimbursementDTOValidator()
    {
 RuleFor(x => x.ReceivedDt)
                .NotEmpty().WithMessage("Received Date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Received Date cannot be in the future.");

            RuleFor(x => x.WRReferenceNum)
                .NotEmpty().WithMessage("Worker Reimbursement Reference Number is required.")
                .MaximumLength(50).WithMessage("Worker Reimbursement Reference Number cannot exceed 50 characters.");

            RuleFor(x => x.CMSReferenceNum)
                .GreaterThan(0).When(x => x.CMSReferenceNum.HasValue).WithMessage("CMS Reference Number must be greater than 0.");

            RuleFor(x => x.ClaimNumber)
                .NotEmpty().WithMessage("Claim Number is required.")
                .MaximumLength(50).WithMessage("Claim Number cannot exceed 50 characters.");

            RuleFor(x => x.ExpenseTypeTXT)
                .NotEmpty().WithMessage("Expense Type is required.")
                .MaximumLength(100).WithMessage("Expense Type cannot exceed 100 characters.");

            RuleFor(x => x.DescriptionTXT)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).When(x => x.Quantity.HasValue).WithMessage("Quantity must be greater than 0.");

            RuleFor(x => x.StatusTXT)
                .NotEmpty().WithMessage("Status is required.")
                .MaximumLength(50).WithMessage("Status cannot exceed 50 characters.");

            RuleFor(x => x.PurchasedDt)
                .NotEmpty().WithMessage("Purchased Date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Purchased Date cannot be in the future.");

            RuleFor(x => x.RequestAmt)
                .GreaterThan(0).WithMessage("Request Amount must be greater than 0.");

            RuleFor(x => x.ReimbursedAmt)
                .GreaterThanOrEqualTo(0).When(x => x.ReimbursedAmt.HasValue).WithMessage("Reimbursed Amount must be greater than or equal to 0.");

            RuleFor(x => x.PdfGuid)
                .NotEmpty().WithMessage("PdfGuid is required.")
                .Must(guid => Guid.TryParse(guid.ToString(), out _)).WithMessage("Invalid Guid format for PdfGuid.");

            RuleFor(x => x.AddedByUser)
                .NotEmpty().WithMessage("Added By User is required.")
                .MaximumLength(100).WithMessage("Added By User cannot exceed 100 characters.");

            RuleFor(x => x.AddedDTM)
                .NotEmpty().WithMessage("Added Date and Time is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Added Date and Time cannot be in the future.");

            RuleFor(x => x.ModifiedByUser)
                .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.ModifiedByUser)).WithMessage("Modified By User cannot exceed 100 characters.");

            RuleFor(x => x.ModifiedDTM)
                .LessThanOrEqualTo(DateTime.UtcNow).When(x => x.ModifiedDTM.HasValue).WithMessage("Modified Date and Time cannot be in the future.");

            RuleFor(x => x.CustomerCareNumber)
                .NotEmpty().WithMessage("Customer Care Number is required.")
                .MaximumLength(50).WithMessage("Customer Care Number cannot exceed 50 characters.");
    }
}