using Api.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class MenuSection
    {
        public MenuSection()
        {
            MenuItems = new HashSet<MenuItem>();
        }
        public int Id { get; set; }

        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
