using Contracts;
using Entities.Models;
using Moq;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void GetAllCompaniesAsync_ReturnsListOfCompanies_WithASingleCompany()
    {
        // arrange
        var mockRepo = new Mock<ITestReimbursementRepository>();
        mockRepo.Setup(repo => (repo.GetAllTestReimbursementAsync(false))).Returns(Task.FromResult(GetCompanies()));

        // act
        var result = mockRepo.Object.GetAllTestReimbursementAsync(false).GetAwaiter().GetResult().ToList();

        // assert
        Assert.IsType<List<TestReimbursement>>(result);
        Assert.Single(result);
    }

    public IEnumerable<TestReimbursement> GetCompanies()
    {
        return new List<TestReimbursement>
        {
            new TestReimbursement
            {
                Id = Guid.NewGuid(),
                Name = "Test TestReimbursement",
                Country = "United States",
                Address = "908  Woodrow Way"
            }
        };
    }
}