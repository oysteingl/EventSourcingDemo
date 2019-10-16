using System;

namespace BlazorApp.Data
{
    public class PatientStatusViewModel
    {
        public string PatientName { get; set; }

        public string CheckInStatus { get; set; }

        public DateTime LastChange { get; set; }

    }
}
