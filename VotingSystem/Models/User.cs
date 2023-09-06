using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Models
{
	public class User 
	{
		[Key]
		 public int Id { get; set; }
		public string UserFullName { get; set; }
		 public string Email { get; set; }
		public string Password { get; set; }
		public string PasswordSalt { get; set; }
		public int Age { get; set; }
	}
}
