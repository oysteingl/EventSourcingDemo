using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Data
{
    public class PatientNameService
    {
        private List<PatientViewModel> _knownPatients = new List<PatientViewModel>();
        public string GetPatientName(Guid patientId)
        {
            if (_knownPatients.FirstOrDefault(model => model.Id.Equals(patientId)) is PatientViewModel knownPatient)
            {
                return knownPatient.PatientName;
            }

            var newPatient = new PatientViewModel {Id = patientId, PatientName = new Bogus.DataSets.Name().FullName()};
            _knownPatients.Add(newPatient);

            return newPatient.PatientName;

        }
    }
}