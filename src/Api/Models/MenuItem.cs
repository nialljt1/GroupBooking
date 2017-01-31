using Api.Models.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        public int MenuSectionId { get; set; }
        public virtual MenuSection MenuSection { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public int? Number { get; set; }

        public int DisplayOrder { get; set; }
    }
}
