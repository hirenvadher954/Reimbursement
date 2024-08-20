using System;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class TestReimbursementRepository : RepositoryBase<TestReimbursement>, ITestReimbursementRepository
	{
		public TestReimbursementRepository(RepositoryContext repositoryContext): base(repositoryContext)
		{
		}

		public async  Task<IEnumerable<TestReimbursement>> GetAllTestReimbursementAsync(bool trackChanges) =>
			await FindAll(trackChanges)
			.OrderBy(c => c.Name)
			.ToListAsync();

        public async Task<TestReimbursement?> GetTestReimbursementAsync(Guid testReimbursementId, bool trackChanges) =>
			await FindByCondition(c => c.Id.Equals(testReimbursementId), trackChanges)
			.SingleOrDefaultAsync();

        public void CreateTestReimbursement(TestReimbursement testReimbursement) => Create(testReimbursement);

		public async  Task<IEnumerable<TestReimbursement>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
			await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();

		public void DeleteTestReimbursement(TestReimbursement testReimbursement) => Delete(testReimbursement);
	}
}

