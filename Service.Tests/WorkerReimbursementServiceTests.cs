using AutoMapper;
using Contracts;
using Contracts.Repositories;
using Entities.Models;
using Entities.Models.DataTransferObjects;
using Moq;
using Service;

namespace Service.Tests;
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
            ReceivedDt = DateTime.UtcNow,
            WRReferenceNum = "WR-12345",
            ClaimNumber = "CL-98765",
            ExpenseTypeTXT = "Travel",
            DescriptionTXT = "Travel expenses for conference",
            RequestAmt = 500.00m,
            ReimbursedAmt = 450.00m,
            PdfGuid = Guid.NewGuid().ToString(),
            StatusTXT = "Approved"
        };

        var workerReimbursement = new WorkerReimbursement
        {
            ReceivedDt = workerReimbursementDto.ReceivedDt,
            WRReferenceNum = workerReimbursementDto.WRReferenceNum,
            CMSReferenceNum = null, 
            ClaimNumber = workerReimbursementDto.ClaimNumber,
            ExpenseTypeTXT = workerReimbursementDto.ExpenseTypeTXT,
            DescriptionTXT = workerReimbursementDto.DescriptionTXT,
            Quantity = 1, 
            StatusTXT = workerReimbursementDto.StatusTXT,
            PurchasedDt = DateTime.UtcNow.AddDays(-10), 
            RequestAmt = workerReimbursementDto.RequestAmt,
            ReimbursedAmt = workerReimbursementDto.ReimbursedAmt,
            PdfGuid = workerReimbursementDto.PdfGuid,
            AddedByUser = "TestUser",
            AddedDTM = DateTime.UtcNow,
            ModifiedByUser = "TestUser",
            ModifiedDTM = DateTime.UtcNow,
            CustomerCareNumber = "800-123-4567"
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
        Assert.Equal(workerReimbursementDto.WRReferenceNum, result.WRReferenceNum);
        Assert.Equal(workerReimbursementDto.ClaimNumber, result.ClaimNumber);
        Assert.Equal(workerReimbursementDto.RequestAmt, result.RequestAmt);
        Assert.Equal(workerReimbursementDto.ReimbursedAmt, result.ReimbursedAmt);
        Assert.Equal(workerReimbursementDto.StatusTXT, result.StatusTXT);
    }
}
