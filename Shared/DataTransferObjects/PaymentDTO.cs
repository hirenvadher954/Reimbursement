namespace Entities.Models.DataTransferObjects;

public class PaymentDTO : BaseEntityDTO<long>
{
    public string PayeeID { get; set; }
    public string PayeeName { get; set; }
    public DateTime? PaymentDate { get; set; }
    public decimal? PaymentAmount { get; set; }
    public string PaymentCategory { get; set; }
    public string DeliveryMethod { get; set; }
    public string PaymentStatus { get; set; }
    public DateTime? PaymentStatusDate { get; set; }
    public string PaymentReference { get; set; }
    public string PayeeType { get; set; }
}
