using AutoMapper;
using Contracts;
using Contracts.Repositories;
using Entities.Models;
using Entities.Models.DataTransferObjects;
using Moq;
using Service;

public class WorkerReimbursementServiceTests
{
    private readonly Mock<IWorkerReimbursementRepository> _workerReimbursementRepositoryMock;
    private readonly Mock<ILoggerManager> _loggerMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly WorkerReimbursementService _service;

    public WorkerReimbursementServiceTests()
    {
        _workerReimbursementRepositoryMock = new Mock<IWorkerReimbursementRepository>();
        _loggerMock = new Mock<ILoggerManager>();
        _mapperMock = new Mock<IMapper>();

        var repositoryManagerMock = new Mock<IRepositoryManager>();
        repositoryManagerMock.Setup(r => r.WorkerReimbursement)
                             .Returns(_workerReimbursementRepositoryMock.Object);

        _service = new WorkerReimbursementService(repositoryManagerMock.Object, _loggerMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task CreateWorkerReimbursementAsync_ValidData_ReturnsWorkerReimbursementDTO()
    {
        // Arrange
        var workerReimbursementDto = new WorkerReimbursementDTO
        {
            // Initialize properties here
        };

        var workerReimbursement = new WorkerReimbursement
        {
            // Initialize properties here
        };

        _mapperMock.Setup(m => m.Map<WorkerReimbursement>(workerReimbursementDto))
            .Returns(workerReimbursement);

        _workerReimbursementRepositoryMock.Setup(r => r.CreateWorkerReimbursement(workerReimbursement));

        var repositoryManagerMock = new Mock<IRepositoryManager>();
        repositoryManagerMock.Setup(r => r.SaveAsync())
            .Returns(Task.CompletedTask);

        _mapperMock.Setup(m => m.Map<WorkerReimbursementDTO>(workerReimbursement))
            .Returns(workerReimbursementDto);

        // Act
        var result = await _service.CreateWorkerReimbursementAsync(workerReimbursementDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(workerReimbursementDto, result);
        _mapperMock.Verify(m => m.Map<WorkerReimbursement>(It.IsAny<WorkerReimbursementDTO>()), Times.Once);
        _workerReimbursementRepositoryMock.Verify(r => r.CreateWorkerReimbursement(It.IsAny<WorkerReimbursement>()), Times.Once);
        repositoryManagerMock.Verify(r => r.SaveAsync(), Times.Once);
        _mapperMock.Verify(m => m.Map<WorkerReimbursementDTO>(It.IsAny<WorkerReimbursement>()), Times.Once);
    }
}
