using System;
using Entities.Models;

namespace Service.Contracts
{
	public interface IServiceManager
	{
		ITestReimbursementService TestReimbursementService { get; }
		IAuthenticationService AuthenticationService { get; }
		
		IServiceBase<TDocument, TDto, TId> GetServiceBase<TDocument, TDto, TId>()
			where TDocument : BaseEntity<TId>;
	}
}

