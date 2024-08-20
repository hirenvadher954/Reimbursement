﻿using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
	public class TestReimbursementConfiguration : IEntityTypeConfiguration<TestReimbursement>
	{
		public void Configure(EntityTypeBuilder<TestReimbursement> builder)
        {
			builder.HasData
			(
				new TestReimbursement
                {
					Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
					Name = "IT_Solutions Ltd",
					Address = "583 Wall Dr. Gwynn Oak, MD 21207",
					Country = "CA"
                },
				new TestReimbursement
                {
					Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
					Name = "Admin_Solutions Ltd",
					Address = "312 Forest Avenue, BF 923",
					Country = "CA"
                }
			);
        }
	}
}

