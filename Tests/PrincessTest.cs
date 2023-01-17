using Microsoft.Extensions.Hosting;
using Moq;
using FluentAssertions;

namespace Tests
{
    public class PrincessTest
    {
        private Mock<IHostApplicationLifetime> _lifetime;
        private Mock<IGenerator> _candidateGenerator;

        [SetUp]
        public void Setup()
        {
            _lifetime = new Mock<IHostApplicationLifetime>();
            _candidateGenerator = new Mock<IGenerator>();
        }

        List<Сandidate> CreateCandidateListForPrincessWhoNotMarried()
        {
            var candidates = new List<Сandidate>();
            for (int i = 100; i > 0; i--)
            {
                string name = Randomizer.GetRandomName();
                int mark = i;
                candidates.Add(new Сandidate());
            }
            return candidates;
        }

        [Test]
        public void FindBestCandidate_PrincessNotMarried()
        {
            List<Сandidate> candidateList = CreateCandidateListForPrincessWhoNotMarried();
            _candidateGenerator.Setup(candidateGenerator => candidateGenerator.CreateListСandidate()).Returns(candidateList);
            Hall hall = new Hall(_candidateGenerator.Object);
            var friend = new Friend(hall);
            var princess = new Princess(hall, friend, _lifetime.Object);

            IСandidateForPrincess candidate = princess.FindBestСandidate();
            int happyMark;
            if (princess.ThinkAboutСandidate(candidate))
            {
                happyMark = princess.GetMark(candidate);
            }
            happyMark.Should().Be(10);
        }

        List<Сandidate> CreateCandidateListForPrincessWhoMarriedOnLooser()
        {
            var candidates = new List<Сandidate>();
            for (int i = 1; i <= 100; i++)
            {
                string name = Randomizer.GetRandomName();
                int mark = i;
                candidates.Add(new Сandidate());
            }
            return candidates;
        }

        [Test]
        public void FindBestCandidate_PrincessMarriedOnLooser()
        {
            List<Сandidate> candidateList = CreateCandidateListForPrincessWhoMarriedOnLooser();
            _candidateGenerator.Setup(candidateGenerator => candidateGenerator.CreateListСandidate()).Returns(candidateList);
            Hall hall = new Hall(_candidateGenerator.Object);
            var friend = new Friend(hall);
            var princess = new Princess(hall, friend, _lifetime.Object);

            IСandidateForPrincess candidate = princess.FindBestСandidate();
            int happyMark;
            if (princess.ThinkAboutСandidate(candidate))
            {
                happyMark = princess.GetMark(candidate);
            }
            happyMark.Should().Be(0);
        }

        List<Сandidate> CreateCandidateListForPrincessWhoMarriedOnBestCandidate()
        {
            var candidates = new List<Сandidate>();
            for (int i = 1; i <= 37; i++)
            {
                string name = Randomizer.GetRandomName();
                int mark = i;
                candidates.Add(new Сandidate());
            }
            for (int i = 100; i > 37; i--)
            {
                string name = Randomizer.GetRandomName();
                int mark = i;
                candidates.Add(new Сandidate());
            }
            return candidates;
        }

        [Test]
        public void FindBestCandidate_PrincessMarriedOnBestCandidate()
        {
            List<Сandidate> candidateList = CreateCandidateListForPrincessWhoMarriedOnBestCandidate();
            _candidateGenerator.Setup(candidateGenerator => candidateGenerator.CreateListСandidate()).Returns(candidateList);
            Hall hall = new Hall(_candidateGenerator.Object);
            var friend = new Friend(hall);
            var princess = new Princess(hall, friend, _lifetime.Object);
            
            IСandidateForPrincess candidate = princess.FindBestСandidate();
            int happyMark;
            if (princess.ThinkAboutСandidate(candidate))
            {
                happyMark = princess.GetMark(candidate);
            }
            happyMark.Should().Be(100);
        }

        List<Сandidate> CreateCandidateListWithOneCandidate()
        {
            var candidateList = new List<Сandidate>();
            string name = Randomizer.GetRandomName();
            int mark = Randomizer.GetRandomWithoutRepeatMark();
            var candidate = new Сandidate();
            candidateList.Add(candidate);
            return candidateList;
        }

        [Test]
        public void FindBestCandidate_NoCandidates_ThrowException()
        {
            List<Сandidate> candidateList = CreateCandidateListWithOneCandidate();
            _candidateGenerator.Setup(candidateGenerator => candidateGenerator.CreateListСandidate()).Returns(candidateList);
            Hall hall = new Hall(_candidateGenerator.Object);
            var friend = new Friend(hall);
            var princess = new Princess(hall, friend, _lifetime.Object);

            princess.Invoking(p => p.FindBestСandidate())
                .Should().Throw<Exception>()
                .WithMessage("No candidates anymore");
        }
    }
}
