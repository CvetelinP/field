using System.Threading.Tasks;

namespace AspNetCoreTemplate.Services.Data
{
    public interface IVoteService
    {
        Task VoteAsync(int postId, string userId, bool isUpVote);
    }
}
