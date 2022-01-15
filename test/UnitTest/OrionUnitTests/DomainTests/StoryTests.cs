
using FluentAssertions;
using Orion.Domain.SeedWork;
using Orion.Domain.StoryDomain.Entities;
using System;
using System.Linq;
using Xunit;

namespace OrionUnitTests.DomainTests
{
    public class StoryTests
    {
        [Fact]
        public void CreateStory_IfBadWordIsNotPassed_ShouldCreateStoryObject()
        {
            //arrange
            string storyText = "this is a good story";

            //act
            var story = Story.Create(storyText);

            //assert
            story.Should().NotBeNull();
            story.Text.Should().Be(storyText);
        }

        [Fact]
        public void CreateStory_IfBadWordIsPassed_ShouldThrowException()
        {
            //arrange
            string storyText = "this is a badword3";

            //act
            Action act = () => Story.Create(storyText);

            //assert
            act.Should().Throw<BusinessRuleValidationException>()
                        .Where(ex => ex.Errors.First().Equals(ErrorMessages.DetectedBadWordsInText));
        }
    }
}
