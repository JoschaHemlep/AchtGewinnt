using System;
using AchtGewinnt.Models;
using AchtGewinnt.Services;
using AchtGewinnt.ViewModels;
using DynamicData;
using FluentAssertions;
using Xunit;

namespace AchtGewinnt.Tests.ViewModels
{
    public class MeetingViewModelTests
    {
        private readonly MeetingViewModel viewModel;

        public MeetingViewModelTests()
        {
            viewModel = new MeetingViewModel(new EnumService());
        }

        [Theory(DisplayName = nameof(RemoveSelectedMeetingTest))]
        [InlineData(true)] // Remove meeting confirmed
        [InlineData(false)] // Remove meeting NOT confirmed
        public void RemoveSelectedMeetingTest(bool confirm)
        {
            // Arrange
            var meeting = new Meeting { Id = 1, Date = DateTimeOffset.UtcNow, Title = "Test", Description = "Test Description" };
            viewModel.Meetings.Add(meeting);
            viewModel.SelectedMeeting = meeting;
            viewModel.ConfirmRemoveInteraction.RegisterHandler(i => i.SetOutput(confirm));

            // Act
            viewModel.RemoveMeetingCommand.Execute();

            // Assert
            if (confirm)
            {
                viewModel.SelectedMeeting.Should().NotBe(meeting);
                viewModel.Meetings4View.Should().NotContain(meeting);
            }
            else
            {
                viewModel.SelectedMeeting.Should().Be(meeting);
                viewModel.Meetings4View.Should().Contain(meeting);
            }
        }
    }
}
