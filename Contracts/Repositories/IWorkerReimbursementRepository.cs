using System;
using Entities.Models;

namespace Contracts.Repositories;

public interface IWorkerReimbursementRepository : IRepositoryBase<WorkerReimbursement>
{
    void CreateWorkerReimbursement(WorkerReimbursement testReimbursement);
}