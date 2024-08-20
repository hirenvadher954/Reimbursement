using System;
namespace Shared.DataTransferObjects
{
    public record TestReimbursementDTO
    {
        public Guid Id { get; init; } // makes it inmutable
        public string? Name { get; init; }
        public string? FullAddress { get; init; }
    }
}

