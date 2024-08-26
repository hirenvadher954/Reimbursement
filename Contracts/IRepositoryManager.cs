using System;
using Entities.Models;

namespace Contracts
{
	public interface IRepositoryManager
	{
		ITestReimbursementRepository TestReimbursement { get; }
		
		public IRepositoryBase<TDocument> GetRepository<TDocument, TId>()
			where TDocument : BaseEntity<TId>;
		
		Task SaveAsync();
	}
}

