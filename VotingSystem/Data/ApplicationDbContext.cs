using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using VotingSystem.Models;

namespace VotingSystem.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		
		public DbSet<VoteAnswer> VoteAnswers { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Vote> Votes{ get; set; }
	}
}