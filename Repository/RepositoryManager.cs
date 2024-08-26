using System;
using Contracts;
using Contracts.Repositories;
using Entities.Models;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
	{
		private readonly RepositoryContext _repositoryContext;
		private readonly Lazy<IWorkerReimbursementRepository> _testReimbursementRepository;

		public RepositoryManager(RepositoryContext repositoryContext)
		{
			_repositoryContext = repositoryContext;
			_testReimbursementRepository = new Lazy<IWorkerReimbursementRepository>(() => new WorkerReimbursementRepository(repositoryContext));
		}
		
		public IRepositoryBase<TDocument> GetRepository<TDocument, TId>() where TDocument : BaseEntity<TId>
		{
			return new RepositoryBase<TDocument>(_repositoryContext);
		}

		public IWorkerReimbursementRepository WorkerReimbursement => _testReimbursementRepository.Value;

		public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
	}
}

