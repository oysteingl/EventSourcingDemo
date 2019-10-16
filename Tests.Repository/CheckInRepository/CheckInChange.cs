using System;

namespace Tests.Repository.CheckInRepository
{
    public class CheckInChange : ICheckInChange
    {
        public CheckInChange()
        {
            ChangeId = Guid.NewGuid();
        }
        public CheckInStatus CheckInStatus { get; set; }
        public Guid ChangeId { get; set; }
    }
}