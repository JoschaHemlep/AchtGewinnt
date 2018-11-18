using System;
using AchtGewinnt.Models;
using AchtGewinnt.ViewModels;
using DynamicData;
using FluentAssertions;
using NUnit.Framework;

namespace AchtGewinnt.Tests.ViewModels
{
    public class MeetingViewModelTests
    {
        private MeetingViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            viewModel = new MeetingViewModel();
        }

        [TestCase(true, TestName = "Remove meeting confirmed")]
        [TestCase(false, TestName = "Remove meeting NOT confirmed")]
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
