using Entities.Models;
using Shared.DataTransferObjects.WorkerReimbursements;
using Shared.WorkerReimbursements;

namespace Service.Contracts;

public interface IWorkerReimbursementService : IServiceBase<WorkerReimbursement, WorkerReimbursementDTO, Guid>
{
    Task<WorkerReimbursementDTO> CreateWorkerReimbursementAsync(WorkerReimbursementDTO testReimbursementDto);
    Task<WorkerReimbursementDTO> UpdateWithCmsResponse( UpdateCmsResponseDTO dto);
}