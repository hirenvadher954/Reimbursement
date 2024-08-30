using Shared.DataTransferObjects;

namespace Shared.WorkerReimbursements;

public class WorkerReimbursementDTO : BaseEntityDTO<Guid>
{
    public DateTime ReceivedDt { get; set; }
    public string? WRReferenceNum { get; set; } = string.Empty;
    public long? CMSReferenceNum { get; set; }
    public string ClaimNumber { get; set; } = string.Empty;
    public string ExpenseTypeTXT { get; set; } = string.Empty;
    public string DescriptionTXT { get; set; } = string.Empty;
    public int? Quantity { get; set; }
    public string? StatusTXT { get; set; }
    public DateTime PurchasedDt { get; set; }
    public decimal RequestAmt { get; set; }
    public decimal? ReimbursedAmt { get; set; }
    public Guid PdfGuid { get; set; }
    public string AddedByUser { get; set; } = string.Empty;
    public DateTime AddedDTM { get; set; }
    public string? ModifiedByUser { get; set; } = string.Empty;
    public DateTime? ModifiedDTM { get; set; }
    public string CustomerCareNumber { get; set; } = string.Empty;
}
