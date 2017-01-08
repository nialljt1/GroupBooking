using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ClientModels
{
    public class ClientBookingModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime StartingAt { get; set; }
        public int NumberOfDiners { get; set; }
        public string Menu { get; set; }
    }

    public class FilterCriteria
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool isCancelled { get; set; }
    }
}
