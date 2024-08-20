using System;
namespace Contracts
{
	public interface IRepositoryManager
	{
		ITestReimbursementRepository TestReimbursement { get; }
		Task SaveAsync();
	}
}

