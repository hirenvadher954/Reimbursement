using System;
using Contracts;
using Entities.Models;

namespace Repository
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly RepositoryContext _repositoryContext;
		private readonly Lazy<ITestReimbursementRepository> _testReimbursementRepository;

		public RepositoryManager(RepositoryContext repositoryContext)
		{
			_repositoryContext = repositoryContext;
			_testReimbursementRepository = new Lazy<ITestReimbursementRepository>(() => new TestReimbursementRepository(repositoryContext));
		}
		
		public IRepositoryBase<TDocument> GetRepository<TDocument, TId>() where TDocument : BaseEntity<TId>
		{
			return new RepositoryBase<TDocument>(_repositoryContext);
		}

		public ITestReimbursementRepository TestReimbursement => _testReimbursementRepository.Value;

		public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
	}
}

