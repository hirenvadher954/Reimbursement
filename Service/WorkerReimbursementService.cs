using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using Shared.DataTransferObjects.WorkerReimbursements;
using Shared.WorkerReimbursements;

namespace Service;

public sealed class WorkerReimbursementService : ServiceBase<WorkerReimbursement, WorkerReimbursementDTO, Guid>,
    IWorkerReimbursementService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public WorkerReimbursementService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : base(
        repository, mapper)
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

    public async Task<WorkerReimbursementDTO> UpdateWithCmsResponse(UpdateCmsResponseDTO dto)
    {
        WorkerReimbursement? document = await _repository.WorkerReimbursement
            .FindByCondition(x => x.Id.Equals(dto.Id), false).SingleOrDefaultAsync();

        if (document == null)
        {
            throw new NotFoundException($"Worker reimbursement with id {dto.Id} not found");
        }

        document.CMSReferenceNum = dto.CmsReferenceNumber;
        document.PdfGuid = dto.PdfGuid;
        _repository.WorkerReimbursement.Update(document);
        await _repository.SaveAsync();
        WorkerReimbursementDTO documentToReturn = _mapper.Map<WorkerReimbursementDTO>(document);
        return documentToReturn;
    }
}