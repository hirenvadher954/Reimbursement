using System;
using Service.Contracts;
using Contracts;
using AutoMapper;
using Shared.DataTransferObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Entities.Models;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ITestReimbursementService> _testReimbursementService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper,
            UserManager<User> userManager, IConfiguration configuration)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _testReimbursementService = new Lazy<ITestReimbursementService>(() => new TestReimbursementService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() =>
                new AuthenticationService(userManager, logger, mapper, configuration));
        }

        public ITestReimbursementService TestReimbursementService => _testReimbursementService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IServiceBase<TDocument, TDto, TId> GetServiceBase<TDocument, TDto, TId>()
            where TDocument : BaseEntity<TId>
        {
            return new ServiceBase<TDocument, TDto, TId>(_repositoryManager, _mapper);
        }
    }
}