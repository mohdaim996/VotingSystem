using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Models
{
	public class Vote
	{
		[Key]
		public int Id { get; set; }
		public string QuestionText { get; set; }
		public bool IsCurrent { get; set; }	
		public DateTime AddedDate { get; set; }
	}
}
