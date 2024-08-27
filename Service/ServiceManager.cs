using System;
using Service.Contracts;
using Contracts;
using AutoMapper;
using Shared.DataTransferObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Entities.Models;
using IWorkerReimbursementService = Service.Contracts.IWorkerReimbursementService;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IWorkerReimbursementService> _testReimbursementService;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, IConfiguration configuration)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _testReimbursementService = new Lazy<IWorkerReimbursementService>(() => new WorkerReimbursementService(repositoryManager, logger, mapper));
        }

        public IWorkerReimbursementService WorkerReimbursementService => _testReimbursementService.Value;
        public IServiceBase<TDocument, TDto, TId> GetServiceBase<TDocument, TDto, TId>()
            where TDocument : BaseEntity<TId>
        {
            return new ServiceBase<TDocument, TDto, TId>(_repositoryManager, _mapper);
        }
    }
}