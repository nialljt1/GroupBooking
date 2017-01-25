using Api.Models.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class DinerMenuItem
    {
        public int DinerId { get; set; }
        public virtual Diner Diner { get; set; }

        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }

        [StringLength(1000)]
        public string Note { get; set; }
    }
}
