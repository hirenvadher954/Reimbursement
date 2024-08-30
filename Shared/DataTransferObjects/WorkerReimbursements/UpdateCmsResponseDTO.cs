namespace Shared.DataTransferObjects.WorkerReimbursements;

public class UpdateCmsResponseDTO
{
    public Guid Id { get; set; }
    public long CmsReferenceNumber { get; set; }
    public Guid PdfGuid { get; set; }
}