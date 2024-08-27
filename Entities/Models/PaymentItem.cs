namespace Entities.Models;

public class PaymentItem :  BaseEntity<long>
{
    public long? PaymentID { get; set; }
    public string ClaimNumber { get; set; }
    public string ItemDescription { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public decimal? InvoiceAmount { get; set; }
    public decimal? PaymentAmount { get; set; }
    public string EntitledName { get; set; }
    public long? InstructLineItemID { get; set; }
    public string ItemCode { get; set; }
    public string InvoiceNumber { get; set; }
    public long? InvoiceID { get; set; }
    public long? WorkerCCN { get; set; }
    public string WorkerName { get; set; }
    public string AddedByUser { get; set; } = string.Empty;
    public DateTime AddedDTM { get; set; }
    public string ModifiedByUser { get; set; } = string.Empty;
    public DateTime ModifiedDTM { get; set; }
    public string ThirdPartyPayeeID { get; set; }

    // Navigation property to Payment
    public Payment Payment { get; set; }
}
