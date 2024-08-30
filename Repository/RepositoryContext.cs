using System;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class RepositoryContext : DbContext
    {
		public RepositoryContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
			modelBuilder.Entity<Payment>()
				.HasMany(p => p.PaymentItems)
				.WithOne(pi => pi.Payment)
				.HasForeignKey(pi => pi.PaymentID);
		}

		public DbSet<Payment> Payments { get; set; }
		public DbSet<PaymentItem> PaymentItems { get; set; }
		public DbSet<WorkerReimbursement> WorkerReimbursements { get; set; }
	}
}

