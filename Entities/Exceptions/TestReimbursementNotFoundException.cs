using System;
namespace Entities.Exceptions
{
	public sealed class TestReimbursementNotFoundException : NotFoundException
	{
		public TestReimbursementNotFoundException(Guid id) : base($"The reimbursement with id: { id } doesn't exist in the database.")
		{
		}
	}
}

