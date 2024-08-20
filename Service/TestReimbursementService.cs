using System;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class TestReimbursementService : ITestReimbursementService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public TestReimbursementService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TestReimbursementDTO>> GetAllTestReimbursementAsync(bool trackChanges)
        {
            var reimbursements = await _repository.TestReimbursement.GetAllTestReimbursementAsync(trackChanges);

            var reimbursementDtos = _mapper.Map<IEnumerable<TestReimbursementDTO>>(reimbursements);

            return reimbursementDtos;
        }

        public async Task<TestReimbursementDTO> GetTestReimbursementAsync(Guid id, bool trackChanges)
        {
            var reimbursement = await GetReimbursementAndCheckIfItExists(id, trackChanges);

            var reimbursementDto = _mapper.Map<TestReimbursementDTO>(reimbursement);
            return reimbursementDto;
        }


        public async Task<IEnumerable<TestReimbursementDTO>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var entities = await _repository.TestReimbursement.GetByIdsAsync(ids, trackChanges);

            if (ids.Count() != entities.Count())
                throw new CollectionByIdsBadRequestException();

            var testReimbursementDtos = _mapper.Map<IEnumerable<TestReimbursementDTO>>(entities);
            return testReimbursementDtos;
        }


        public async Task DeleteTestReimbursementAsync(Guid reimbursementId, bool trackChanges)
        {
            var testReimbursement = await GetReimbursementAndCheckIfItExists(reimbursementId, trackChanges);

            _repository.TestReimbursement.DeleteTestReimbursement(testReimbursement);
            await _repository.SaveAsync();
        }


        private async Task<TestReimbursement> GetReimbursementAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var testReimbursement = await _repository.TestReimbursement.GetTestReimbursementAsync(id, trackChanges);
            if (testReimbursement is null)
                throw new TestReimbursementNotFoundException(id);

            return testReimbursement;
        }
    }
}