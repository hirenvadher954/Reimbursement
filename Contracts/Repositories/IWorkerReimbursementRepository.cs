using System;
using Entities.Models;

namespace Contracts.Repositories;

public interface IWorkerReimbursementRepository
{
    void CreateWorkerReimbursement(WorkerReimbursement testReimbursement);
}