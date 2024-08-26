using System;
using Entities.Models.DataTransferObjects;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IWorkerReimbursementService
{
    Task<WorkerReimbursementDTO> CreateWorkerReimbursementAsync(WorkerReimbursementDTO testReimbursementDto);
}