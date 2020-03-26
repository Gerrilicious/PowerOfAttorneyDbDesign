using System;
using Microsoft.EntityFrameworkCore;
using PowerOfAttorneyDbDesign.Models;

namespace PowerOfAttorneyDbDesign
{
	public class DataContext : DbContext
	{
		public DbSet<User> User { get; set; }

		public DbSet<BillingAddress> BillingAddress { get; set; }

		public DbSet<Company> Company { get; set; }

		public DbSet<DisclosureRequest> DisclosureRequest { get; set; }

		public DbSet<DisclosureResponse> DisclosureResponse { get; set; }

		public DbSet<FinancialInstrument> FinancialInstrument { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
				@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PowerOfAttorneyDbDesign;Integrated Security=true;Trusted_Connection=True;");
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<User>(b =>
			{
				b.Property(u => u.Id)
				 .HasDefaultValueSql("newsequentialid()");
			});

			builder.Entity<UserCompanies>()
			       .HasKey(item => new {item.UserId, item.CompanyId});

			builder.Entity<UserCompanies>()
			       .HasOne<User>(item => item.User)
			       .WithMany(item => item.UserCompanies)
			       .HasForeignKey(item => item.UserId);

			builder.Entity<UserCompanies>()
			       .HasOne<Company>(item => item.Company)
			       .WithMany(item => item.UserCompanies)
			       .HasForeignKey(item => item.CompanyId);

			builder.Entity<Company>(b =>
			{
				b.Property(u => u.Id)
				 .HasDefaultValueSql("newsequentialid()");

				b.HasOne(item => item.BillingAddress)
				 .WithOne(item => item.Company).HasForeignKey<BillingAddress>("BillingAddressId");
			});

			builder.Entity<FinancialInstrument>(b =>
			{
				b.Property(u => u.Id)
				 .HasDefaultValueSql("newsequentialid()");

				b.HasOne(item => item.Company)
				 .WithMany(item => item.FinancialInstruments)
				 .HasForeignKey(item => item.CompanyId)
				 .OnDelete(DeleteBehavior.NoAction);
			});

			builder.Entity<BillingAddress>(b =>
			{
				b.Property(u => u.Id)
				 .HasDefaultValueSql("newsequentialid()");

				b.HasOne(item => item.User)
				 .WithMany(item => item.BillingAddresses).HasForeignKey(item => item.UserId);

				//b.HasOne(item => item.Company)
				// .WithOne(item => item.BillingAddress)
				// .HasForeignKey<Company>("CompanyId");
			});

			builder.Entity<DisclosureRequest>(b =>
			{
				b.Property(u => u.Id)
				 .HasDefaultValueSql("newsequentialid()");

				b.HasOne(item => item.FinancialInstrument)
				 .WithMany(item => item.DisclosureRequests)
				 .HasForeignKey(item => item.FinancialInstrumentId);

				b.HasOne(item => item.Company)
				 .WithMany(item => item.DisclosureRequests)
				 .HasForeignKey(item => item.CompanyId);
			});

			builder.Entity<DisclosureResponse>(b =>
			{
				b.Property(u => u.Id)
				 .HasDefaultValueSql("newsequentialid()");

				b.HasOne(item => item.DisclosureRequest)
				 .WithMany(item => item.DisclosureResponses)
				 .HasForeignKey(item => item.DisclosureRequestId)
				 .OnDelete(DeleteBehavior.NoAction);

				b.HasOne(item => item.Company)
				 .WithMany(item => item.DisclosureResponses)
				 .HasForeignKey(item => item.CompanyId);
			});

			builder.Entity<PowerOfAttorney>(b =>
			{
				b.Property(u => u.Id)
				 .HasDefaultValueSql("newsequentialid()");

				b.HasOne(item => item.FinancialInstrument)
				 .WithMany(item => item.PowerOfAttorneys)
				 .HasForeignKey(item => item.FinancialInstrumentId);

				b.HasOne(item => item.Company)
				 .WithMany(item => item.PowerOfAttorneys)
				 .HasForeignKey(item => item.CompanyId);
			});

			base.OnModelCreating(builder);
		}
	}
}
