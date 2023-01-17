namespace Tests;

using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;

public class FriendTest
{
    private Mock<IGenerator> _candidateGenerator;

    [SetUp]
    public void Setup()
    {
        _candidateGenerator = new Mock<IGenerator>();
    }

    List<Сandidate> CreateCandidateListForFriendTest()
    {
        var candidates = new List<Сandidate>();
        candidates.Add(new Сandidate());
        return candidates;
    }

    [Test]
    public void CompareCandidates_ReturnBest()
    {
        List<Сandidate> candidateList = CreateCandidateListForFriendTest();
        _candidateGenerator.Setup(candidateGenerator => candidateGenerator.CreateListСandidate())
            .Returns(candidateList);
        Hall hall = new Hall(_candidateGenerator.Object);
        var friend = new Friend(hall);

        var bestCandidate = hall.GetNextСandidate();
        var worseCandidate = hall.GetNextСandidate();
        bool compareType = friend.CompareСandidates(bestCandidate, worseCandidate);
        compareType.Should().Be(compareType);
    }

    [Test]
    public void CompareCandidates_ReturnWorse()
    {
        List<Сandidate> candidateList = CreateCandidateListForFriendTest();
        _candidateGenerator.Setup(candidateGenerator => candidateGenerator.CreateListСandidate())
            .Returns(candidateList);
        Hall hall = new Hall(_candidateGenerator.Object);
        var friend = new Friend(hall);

        var bestCandidate = hall.GetNextСandidate();
        var worseCandidate = hall.GetNextСandidate();
        bool compareType = friend.CompareСandidates(worseCandidate, bestCandidate);
        compareType.Should().Be(compareType == false);
    }

    [Test]
    public void CompareIfFriendDontKnow_CompareCandidates_ThrowException()
    {
        List<Сandidate> candidateList = CreateCandidateListForFriendTest();
        _candidateGenerator.Setup(candidateGenerator => candidateGenerator.CreateListСandidate())
            .Returns(candidateList);
        Hall hall = new Hall(_candidateGenerator.Object);
        var friend = new Friend(hall);

        var bestCandidate = candidateList[0];
        var worseCandidate = candidateList[1];
        friend.Invoking(f => f.CompareСandidates(worseCandidate, bestCandidate))
            .Should().Throw<Exception>()
            .WithMessage("Friend can not compare candidates that have not visited princess");
    }
}