using Api.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking()
        {
            Diners = new HashSet<Diner>();
            CreatedAt = DateTimeOffset.Now;

        }
        public int Id { get; set; }

        public Guid Identifier { get; set; }

        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }

        public DateTime StartingAt { get; set; }
        public DateTime CutOffDate { get; set; }

        [Required, StringLength(50)]
        public string OrganiserForename { get; set; }

        [Required, StringLength(50)]
        public string OrganiserSurname { get; set; }

        [Required, StringLength(256)]
        public string OrganiserEmailAddress { get; set; }
        [Required, StringLength(50)]
        public string OrganiserTelephoneNumber { get; set; }

        [Required]
        public int NumberOfDiners { get; set; }
        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        public bool IsCancelled { get; set; }

        [Required]
        [StringLength(450)]
        public string CreatedById { get; set; }
        public virtual AspNetUser CreatedBy { get; set; }

        [Required]
        [StringLength(450)]
        public string LastUpdatedById { get; set; }
        public virtual AspNetUser LastUpdatedBy { get; set; }
        [Required]
        public DateTimeOffset LastUpdatedAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diner> Diners { get; set; }
    }
}
