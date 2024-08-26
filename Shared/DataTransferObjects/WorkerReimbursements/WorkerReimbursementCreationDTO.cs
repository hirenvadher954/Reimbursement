namespace Entities.Models.DataTransferObjects;

public class WorkerReimbursementCreationDTO : BaseEntityDTO<long>
{
    public DateTime ReceivedDt { get; set; }
    public string WRReferenceNum { get; set; } = string.Empty;
    public string ClaimNumber { get; set; } = string.Empty;
    public string ExpenseTypeTXT { get; set; } = string.Empty;
    public string DescriptionTXT { get; set; } = string.Empty;
    public decimal RequestAmt { get; set; }
    public decimal ReimbursedAmt { get; set; }
    public string PdfGuid { get; set; } = string.Empty;
    public string StatusTXT { get; set; } = string.Empty;
}