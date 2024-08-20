using System;
using Entities.Models;

namespace Contracts
{
	public interface ITestReimbursementRepository
	{
		Task<IEnumerable<TestReimbursement>> GetAllTestReimbursementAsync(bool trackChanges);

		Task<TestReimbursement?> GetTestReimbursementAsync(Guid testReimbursementId, bool trackChanges);

		void CreateTestReimbursement(TestReimbursement testReimbursement);

		Task<IEnumerable<TestReimbursement>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);

		void DeleteTestReimbursement(TestReimbursement testReimbursement);
	}
}

