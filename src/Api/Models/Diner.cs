using Api.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Diner
    {
        public Diner()
        {
            CreatedAt = DateTimeOffset.Now;
            DinerMenuItems = new HashSet<DinerMenuItem>();
        }
        public int Id { get; set; }
        public int BookingId { get; set; }
        public virtual Booking Booking { get; set; }

        [Required, StringLength(50)]
        public string Forename { get; set; }

        [Required, StringLength(50)]
        public string Surname { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedById { get; set; }
        public virtual AspNetUser CreatedBy { get; set; }
        public string LastUpdatedById { get; set; }
        public virtual AspNetUser LastUpdatedBy { get; set; }
        public DateTimeOffset LastUpdatedAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DinerMenuItem> DinerMenuItems { get; set; }
    }
}
