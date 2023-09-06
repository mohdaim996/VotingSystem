using Microsoft.EntityFrameworkCore;

using VotingSystem.Data;
using VotingSystem.Models;


    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Check if the database already has data
                if (context.Votes.Any() || context.VoteAnswers.Any())
                {
                    return; // Database has been seeded
                }

                // Insert sample data into the Vote table - Questions Only
                var votes = new List<Vote>
                {
                    new Vote { QuestionText = "Which community project do you believe should receive funding?", IsCurrent = true, AddedDate = DateTime.Parse("2023-09-06 10:00:00") },
                    new Vote { QuestionText = "How often do you participate in community events or projects?", IsCurrent = true, AddedDate = DateTime.Parse("2023-09-06 11:15:00") },
                    new Vote { QuestionText = "What motivates you to support a community project?", IsCurrent = true, AddedDate = DateTime.Parse("2023-09-06 12:30:00") },
                    new Vote { QuestionText = "What aspect of your community do you think needs the most attention right now?", IsCurrent = true, AddedDate = DateTime.Parse("2023-09-06 14:45:00") },
                    new Vote { QuestionText = "Which local organization or group do you believe has made the most positive impact on our community?", IsCurrent = true, AddedDate = DateTime.Parse("2023-09-06 16:00:00") }
                };

                context.Votes.AddRange(votes);
                context.SaveChanges();

                // Insert sample data into the VoteAnswer table with counts set to 0 and UserId set to NULL
                var voteAnswers = new List<VoteAnswer>
                {
                    new VoteAnswer { OptionText = "Community Garden Expansion", VoteId = 1, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Youth Mentorship Program", VoteId = 1, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Park Renovation Project", VoteId = 1, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Senior Citizens' Center Upgrades", VoteId = 1, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Arts and Culture Festival", VoteId = 1, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Sports Facility Improvements", VoteId = 1, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Environmental Cleanup Initiative", VoteId = 1, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "After-School Program Expansion", VoteId = 1, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Regularly", VoteId = 2, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Occasionally", VoteId = 2, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Rarely", VoteId = 2, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Never", VoteId = 2, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "I'm actively involved in multiple community projects!", VoteId = 2, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Enhancing Quality of Life", VoteId = 3, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Strengthening Community Bonds", VoteId = 3, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Environmental Conservation", VoteId = 3, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Supporting Youth Development", VoteId = 3, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Cultural Enrichment", VoteId = 3, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Health and Wellness", VoteId = 3, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Economic Growth", VoteId = 3, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "I support all these reasons!", VoteId = 3, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Education", VoteId = 4, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Healthcare", VoteId = 4, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Public Spaces", VoteId = 4, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Employment Opportunities", VoteId = 4, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Social Services", VoteId = 4, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Environment", VoteId = 4, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Safety and Security", VoteId = 4, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "All of the above", VoteId = 4, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Neighborhood Watch", VoteId = 5, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Environmental Advocates Group", VoteId = 5, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Youth Sports League", VoteId = 5, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Cultural Arts Society", VoteId = 5, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Food Bank and Shelter", VoteId = 5, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Senior Citizens' Association", VoteId = 5, VotesCount = 0, UserId = null },
                    new VoteAnswer { OptionText = "Education Foundation", VoteId = 5, VotesCount = 0, UserId = null },
                };

                context.VoteAnswers.AddRange(voteAnswers);
                context.SaveChanges();
            }
        }
    }

