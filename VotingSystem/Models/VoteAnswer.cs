using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VotingSystem.Migrations;

namespace VotingSystem.Models
{
	public class VoteAnswer
	{
		[Key]
		public int Id { get; set; }
		public string OptionText { get; set; }
		public int VoteId { get; set; }
		public Vote Vote { get; set; }
		public int VotesCount { get; set; } = 0;
		public int? UserId { get; set; }
		public User? User { get; set; }
	}
}
