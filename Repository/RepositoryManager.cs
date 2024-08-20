using System;
using Contracts;

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

		public ITestReimbursementRepository TestReimbursement => _testReimbursementRepository.Value;

		public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
	}
}

