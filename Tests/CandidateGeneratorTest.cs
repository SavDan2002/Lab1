namespace Tests;
using FluentAssertions;
using System.Collections.Generic;
public class CandidateGeneratorTest
{
    [Test]
    public void GenerateUniqueCandidates_ReturnUnique()
    {
        Generator contenderGenerator = new Generator();
        Hall hall = new Hall(contenderGenerator);
        var contenderList = new List<Сandidate>();
        for (int i = 0; i < 100; i++)
        {
            contenderList.Add(hall.GetNextСandidate());
        }
        contenderList.Should().OnlyHaveUniqueItems();
    }
}