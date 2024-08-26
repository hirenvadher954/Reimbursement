using System;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
	public class RepositoryContext : IdentityDbContext<User>
    {
		public RepositoryContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TestReimbursementConfiguration());
			modelBuilder.ApplyConfiguration(new RoleConfiguration());
			
			modelBuilder.Entity<Payment>()
				.HasMany(p => p.PaymentItems)
				.WithOne(pi => pi.Payment)
				.HasForeignKey(pi => pi.PaymentID);
		}

		public DbSet<TestReimbursement>? TestReimbursements { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<PaymentItem> PaymentItems { get; set; }
		public DbSet<WorkerReimbursement> WorkerReimbursements { get; set; }
	}
}

