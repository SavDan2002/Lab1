namespace Tests;

using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;

public class TestHall
{
    private Mock<IGenerator> _candidateGenerator;

    [SetUp]
    public void Setup()
    {
        _candidateGenerator = new Mock<IGenerator>();
    }

    List<Сandidate> CreateCandidateListWithTwoCandidates()
    {
        var candidates = new List<Сandidate>();
        candidates.Add(new Сandidate());
        candidates.Add(new Сandidate());
        return candidates;
    }

    [Test]
    public void GetNextCandidate_ReturnCandidate()
    {
        List<Сandidate> candidateList = CreateCandidateListWithTwoCandidates();
        _candidateGenerator.Setup(candidateGenerator => candidateGenerator.CreateListСandidate())
            .Returns(candidateList);
        Hall hall = new Hall(_candidateGenerator.Object);

        var candidateFirst = candidateList[0];
        var candidate = hall.GetNextСandidate();
        candidate.Should().Be(candidateFirst);
    }

    List<Candidate> CreateCandidateListWithOneCandidate()
    {
        var candidateList = new List<Сandidate>();
        candidateList.Add(new Сandidate());
        return candidateList;
    }

    [Test]
    public void GetNextCandidate_NoCandidates_ThrowException()
    {
        List<Сandidate> candidateList = CreateCandidateListWithOneCandidate();
        _candidateGenerator.Setup(candidateGenerator => candidateGenerator.CreateListCandidate())
            .Returns(candidateList);
        Hall hall = new Hall(_candidateGenerator.Object);
        hall.GetNextСandidate();
        hall.Invoking(h => h.GetNextСandidate()).Should().Throw<Exception>()
            .WithMessage("В коридоре больше нету претендентов!");
    }

    [Test]
    public void GetMarkByName_GetCorrectMark()
    {
        List<Candidate> candidateList = CreateCandidateListWithOneCandidate();
        _candidateGenerator.Setup(candidateGenerator => candidateGenerator.CreateListСandidate())
            .Returns(candidateList);
        Hall hall = new Hall(_candidateGenerator.Object);
        Сandidate candidate = hall.GetNextСandidate();
        int markByName = hall.GetMarkByName(candidate);
        int mark = candidate.Mark;
        markByName.Should().Be(mark);
    }

    [Test]
    public void GetMarkByName_CandidateNotExist_ReturnException()
    {
        List<Сandidate> candidateList = CreateCandidateListWithOneCandidate();
        _candidateGenerator.Setup(candidateGenerator => candidateGenerator.CreateListСandidate())
            .Returns(candidateList);
        Hall hall = new Hall(_candidateGenerator.Object);

        var candidate = new Candidate();

        hall.Invoking(h => h.GetMarkByName(candidate))
            .Should().Throw<Exception>()
            .WithMessage("This candidate does not exist");
    }
}