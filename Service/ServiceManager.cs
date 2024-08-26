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
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper,
            UserManager<User> userManager, IConfiguration configuration)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _testReimbursementService = new Lazy<IWorkerReimbursementService>(() => new WorkerReimbursementService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() =>
                new AuthenticationService(userManager, logger, mapper, configuration));
        }

        public IWorkerReimbursementService WorkerReimbursementService => _testReimbursementService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IServiceBase<TDocument, TDto, TId> GetServiceBase<TDocument, TDto, TId>()
            where TDocument : BaseEntity<TId>
        {
            return new ServiceBase<TDocument, TDto, TId>(_repositoryManager, _mapper);
        }
    }
}