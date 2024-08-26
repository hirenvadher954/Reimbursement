using System;
using Contracts.Repositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class WorkerReimbursementRepository : RepositoryBase<WorkerReimbursement>, IWorkerReimbursementRepository
	{
		public WorkerReimbursementRepository(RepositoryContext repositoryContext): base(repositoryContext)
		{
		}

		public void CreateWorkerReimbursement(WorkerReimbursement testReimbursement) => Create(testReimbursement);
	}
}

