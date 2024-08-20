using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class TestReimbursement
    {
        public TestReimbursement()
        {
        }

        [Column("TestReimbursementId")] public Guid Id { get; set; }

        [Required(ErrorMessage = "TestReimbursement name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "TestReimbursement address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters")]
        public string? Address { get; set; }

        public string? Country { get; set; }
    }
}