using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Features.CheckIn;
using InfraStructure.Repositories.CheckIn;
using Utilities;

namespace BlazorApp.Data
{
    public class CheckInLogService
    {
        private readonly InMemoryCheckInRepository _repository;
        private readonly PatientNameService _nameService;

        public CheckInLogService(InMemoryCheckInRepository repository, PatientNameService nameService)
        {
            _repository = repository;
            _nameService = nameService;
        }

        public class LogViewModel
        {
            public string PatientName { get; set; }
            public Guid Id { get; set; }
            public DateTime TimeStamp { get; set; }

            public string Status { get; set; }
        }

        private string DisplayStatus(CheckInStatus status) =>
            status switch
            {
                CheckInStatus.CheckedIn => "Checked In",
                CheckInStatus.SamplingStarted => "Started sampling",
                CheckInStatus.SamplingEnded => "Finished sampling"
            };

        public Task<LogViewModel[]> GetLog()
        {
            var events = _repository.GetEvents();

            var vms = events.Select(@event => new LogViewModel {Id = @event.EventId, PatientName = _nameService.GetPatientName(@event.PatientId), TimeStamp = DateTimeOffset.FromUnixTimeSeconds(@event.Timestamp).DateTime, Status = DisplayStatus(@event.CheckInStatus)});

            return Task.FromResult(vms.ToArray());
        }
    }
}