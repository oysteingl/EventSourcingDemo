using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Domain.Features.CheckIn;
using FluentAssertions;
using Xunit;

namespace Tests.Unit.CheckInChangedEvent
{
    public class ProcessShould
    {

        [Fact]
        public void AddNewCheckedInPatientToState()
        {
            var currentState = new List<PatientWithStatus>().AsReadOnly();
            var patientId = Guid.NewGuid();

            var checkInChangedEvent = CheckInEventFactory.Create(patientId, CheckInStatus.CheckedIn, DateTime.Now);

            var newState = checkInChangedEvent.Process(currentState);

            newState.Should().Contain(p => p.PatientId == patientId);
        }
        
        [Fact]
        public void UpdateStatusOfExistingPatient()
        {
            var patientId = Guid.NewGuid();
            var currentState = new List<PatientWithStatus>{new PatientWithStatus(patientId, CheckInStatus.CheckedIn, DateTimeOffset.Now.ToUnixTimeSeconds())}.AsReadOnly();

            var checkInChangedEvent = CheckInEventFactory.Create(patientId, CheckInStatus.SamplingStarted, DateTime.Now);

            var newState = checkInChangedEvent.Process(currentState);

            var target = newState.First(p => p.PatientId == patientId);

            target.CheckInStatus.Should().Be(CheckInStatus.SamplingStarted);
        }
    }
}