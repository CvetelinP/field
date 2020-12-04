namespace FieldPlatform.Services.Data
{
    using System.Threading.Tasks;

    public interface IVoteService
    {
        Task VoteAsync(int promoterId, string userId, bool isUpVote);

        int GetVotes(int promoterId);
    }
}
