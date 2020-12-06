namespace FieldPlatform.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FieldPlatform.Data.Common.Repositories;
    using FieldPlatform.Data.Models;
    using FieldPlatform.Data.Repositories;
    using Moq;
    using Xunit;

    public class VotesServiceTest
    {
        [Fact]
        public async Task WhenUserVotesTwoTimesDownVotes()
        {
            var list = new List<Vote>();
            var mockRepo = new Mock<IRepository<Vote>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>())).Callback((Vote vote) => list.Add(vote));
            var service = new VoteService(mockRepo.Object);

            await service.VoteAsync(1, "1", false);
            await service.VoteAsync(1, "1", false);
            var votes = service.GetVotes(1);
            Assert.Equal(-1,votes);
        }
        [Fact]
        public async Task WhenUserVotesTwoTimesUpVotes()
        {
            var list = new List<Vote>();
            var mockRepo = new Mock<IRepository<Vote>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>())).Callback((Vote vote) => list.Add(vote));
            var service = new VoteService(mockRepo.Object);

            await service.VoteAsync(1, "1", true);
            await service.VoteAsync(1, "1", true);
            var votes = service.GetVotes(1);
            Assert.Equal(1, votes);
        }
    }
}
