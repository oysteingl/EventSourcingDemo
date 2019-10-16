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
    public class CheckInStateService
    {
        private readonly InMemoryCheckInRepository _repository;
        private readonly PatientNameService _nameService;

        public CheckInStateService(InMemoryCheckInRepository repository, PatientNameService nameService)
        {
            _repository = repository;
            _nameService = nameService;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };



        private string DisplayStatus(CheckInStatus status) =>
            status switch
            {
                CheckInStatus.CheckedIn => "Checked In",
                CheckInStatus.SamplingStarted => "Started sampling",
                CheckInStatus.SamplingEnded => "Finished sampling"
            };

        public Task<PatientStatusViewModel[]> GetCurrentPatientStatuses(DateTime endDate)
        {
            var events = _repository.GetEvents(endDate);


            var state = CheckInState.Empty;
            state = state.ProcessEvents(events);


            var vms = state.PatientStatuses.Select(ps => new PatientStatusViewModel
            {
                PatientName = _nameService.GetPatientName(ps.PatientId),
                LastChange = ps.LastChange,
                CheckInStatus = DisplayStatus(ps.CheckInStatus)
            });

            return Task.FromResult(vms.ToArray());
        }
    }
}