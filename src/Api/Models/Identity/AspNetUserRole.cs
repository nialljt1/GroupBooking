using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Identity
{
    public partial class AspNetUserRole
    {
        [StringLength(450)]
        public string RoleId { get; set; }

        [ForeignKey("RoleId")]
        public AspNetRole Role { get; set; }

        [StringLength(450)]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public AspNetUser User { get; set; }
    }
}
