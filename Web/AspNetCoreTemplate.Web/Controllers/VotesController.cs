using System.Threading.Tasks;
using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Web.ViewModels.Vote;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTemplate.Web.Controllers
{
    using AspNetCoreTemplate.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVoteService voteService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(IVoteService voteService, UserManager<ApplicationUser> userManager)
        {
            this.voteService = voteService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            await this.voteService.VoteAsync(input.PromoterId, user.Id, input.IsUpVote);
            var votes = this.voteService.GetVotes(input.PromoterId);
            return new VoteResponseModel { VotesCount = votes };
        }
    }
}
