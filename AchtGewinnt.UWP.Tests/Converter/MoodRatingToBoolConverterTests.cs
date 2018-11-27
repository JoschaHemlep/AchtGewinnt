using AchtGewinnt.Models;
using AchtGewinnt.UWP.Converter;
using FluentAssertions;
using Xunit;

namespace AchtGewinnt.UWP.Tests.Converter
{
    public class MoodRatingToBoolConverterTests
    {
        private readonly MoodRatingToBoolConverter converter;

        public MoodRatingToBoolConverterTests()
        {
            converter = new MoodRatingToBoolConverter();
        }

        [Theory(DisplayName = nameof(MoodRatingToBoolConverterTest))]
        [InlineData("0", MoodRating.None, true)]
        [InlineData("1", MoodRating.Yeah, true)]
        [InlineData("2", MoodRating.Meh, true)]
        [InlineData("3", MoodRating.NotMyDay, true)]
        [InlineData("1", MoodRating.NotMyDay, false)]
        [InlineData("4", MoodRating.NotMyDay, false)]
        public void MoodRatingToBoolConverterTest(string parameter, MoodRating value, bool expectedResult)
        {
            // Arrange
            var targetType = typeof(bool);

            // Act
            var result = converter.Convert(value, targetType, parameter, string.Empty);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
