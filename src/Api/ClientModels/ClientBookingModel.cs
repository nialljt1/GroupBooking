using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ClientModels
{
    public class ClientBookingModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string Surname { get; set; }

        [Required, StringLength(256)]
        public string EmailAddress { get; set; }

        [Required, StringLength(50)]
        public string TelephoneNumber { get; set; }
        [Required]
        public DateTime StartingAt { get; set; }
        [Required]
        public DateTime CutOffDate { get; set; }
        [Required]
        public int NumberOfDiners { get; set; }
        [Required]
        public int MenuId { get; set; }

        [StringLength(50)]
        public string Menu { get; set; }
    }

    public class FilterCriteria
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool isCancelled { get; set; }
    }
}
