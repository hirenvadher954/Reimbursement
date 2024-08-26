using System;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ITestReimbursementService
    {
        Task<IEnumerable<TestReimbursementDTO>> GetAllTestReimbursementAsync(bool trackChanges);

        Task<TestReimbursementDTO> GetTestReimbursementAsync(Guid companyId, bool trackChanges);


        Task<IEnumerable<TestReimbursementDTO>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);


        Task DeleteTestReimbursementAsync(Guid reimbursementId, bool trackChanges);
    }
}