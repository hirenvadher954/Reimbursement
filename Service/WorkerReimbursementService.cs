using System;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Entities.Models.DataTransferObjects;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public sealed class WorkerReimbursementService : IWorkerReimbursementService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public WorkerReimbursementService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<WorkerReimbursementDTO> CreateWorkerReimbursementAsync(
        WorkerReimbursementDTO workerReimbursementDto)
    {
        WorkerReimbursement document = _mapper.Map<WorkerReimbursement>(workerReimbursementDto);
        _repository.WorkerReimbursement.CreateWorkerReimbursement(document);
        await _repository.SaveAsync();
        WorkerReimbursementDTO documentToReturn = _mapper.Map<WorkerReimbursementDTO>(document);
        return documentToReturn;
    }
}