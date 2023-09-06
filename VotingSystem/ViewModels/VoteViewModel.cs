using System.Collections.Generic;
using VotingSystem.Models;

public class VoteViewModel
{
	public Vote Vote { get; set; }
	public List<VoteAnswer> VoteAnswers { get; set; }
}
