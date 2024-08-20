using System;
namespace Service.Contracts
{
	public interface IServiceManager
	{
		ITestReimbursementService TestReimbursementService { get; }
		IAuthenticationService AuthenticationService { get; }
	}
}

