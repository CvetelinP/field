namespace AspNetCoreTemplate.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Data.Models.Enum;

    public class VoteService : IVoteService
    {
        private readonly IRepository<Vote> voteRepository;

        public VoteService(IRepository<Vote> voteRepository)
        {
            this.voteRepository = voteRepository;
        }

        public async Task VoteAsync(int promoterId, string userId, bool isUpVote)
        {
            var vote = this.voteRepository.All()
                .FirstOrDefault(x => x.PromoterId == promoterId && x.UserId == userId);
            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = new Vote
                {
                    PromoterId = promoterId,
                    UserId = userId,
                    Type = isUpVote ? VoteType.UpVote : VoteType.DownVote,

                };
                await this.voteRepository.AddAsync(vote);
            }

            await this.voteRepository.SaveChangesAsync();
        }

        public int GetVotes(int promoterId)
        {
            var votes = this.voteRepository.All().Where(x => x.PromoterId == promoterId).Sum(x => (int) x.Type);

            return votes;
        }
    }
}