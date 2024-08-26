using System;
using Contracts.Repositories;
using Entities.Models;

namespace Contracts
{
    public interface IRepositoryManager
	{
		IWorkerReimbursementRepository WorkerReimbursement { get; }
		
		public IRepositoryBase<TDocument> GetRepository<TDocument, TId>()
			where TDocument : BaseEntity<TId>;
		
		Task SaveAsync();
	}
}

