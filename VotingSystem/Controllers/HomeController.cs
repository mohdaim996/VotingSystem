using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Nodes;
using VotingSystem.Data;
using VotingSystem.Migrations;
using VotingSystem.Models;

namespace VotingSystem.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly ILogger<HomeController> _logger;

		public HomeController(ApplicationDbContext dbContext, ILogger<HomeController> logger)
		{
			_dbContext = dbContext;
			_logger = logger;
		}
        public IActionResult Results()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var votes = _dbContext.Votes.ToList();
            var voteViewModels = new List<VoteViewModel>();

            foreach (var vote in votes)
            {
                var voteAnswers = _dbContext.VoteAnswers.Where(va => va.VoteId == vote.Id).ToList();


                var viewModel = new VoteViewModel
                {
                    Vote = vote,
                    VoteAnswers = voteAnswers
                };

                voteViewModels.Add(viewModel);
            }

            return View(voteViewModels);
        }
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var votes = _dbContext.Votes.ToList();
            var voteViewModels = new List<VoteViewModel>();

            foreach (var vote in votes)
            {
                var voteAnswers = _dbContext.VoteAnswers.Where(va => va.VoteId == vote.Id).ToList();


                var viewModel = new VoteViewModel
                {
                    Vote = vote,
                    VoteAnswers = voteAnswers
                };

                voteViewModels.Add(viewModel);
            }

            return View(voteViewModels);
        }

        public IActionResult Privacy()
		{
			return View();
		}
		[HttpPost("Votes")]
		public async Task<IActionResult> Votes()
		{
			try
			{
				using (StreamReader reader = new StreamReader(Request.Body))
				{
					var requestBody = await reader.ReadToEndAsync();
					var jsonData = JsonConvert.DeserializeObject<Dictionary<string, string>>(requestBody);

					// Validate JSON data here

					foreach (var val in jsonData.Values)
					{
						if (int.TryParse(val, out int voteAnswerId))
						{
							// Check if the VoteAnswer with the given ID exists
							var voteAnswer = _dbContext.VoteAnswers.FirstOrDefault(va => va.Id == voteAnswerId);

							if (voteAnswer != null)
							{
								voteAnswer.VotesCount++;
							}
						}
					}

					_dbContext.SaveChanges(); // Save changes to the database

					return Ok("Data received and processed successfully.");
				}
			}
			catch (Exception ex)
			{
				// Log the exception for debugging purposes
				Console.WriteLine("Error: " + ex.Message);

				return BadRequest("An error occurred while processing the data.");
			}
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}