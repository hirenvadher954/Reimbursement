using System;
using Entities.Models;

namespace Service.Contracts
{
	public interface IServiceManager
	{
		IWorkerReimbursementService WorkerReimbursementService { get; }		
		IServiceBase<TDocument, TDto, TId> GetServiceBase<TDocument, TDto, TId>()
			where TDocument : BaseEntity<TId>;
	}
}

