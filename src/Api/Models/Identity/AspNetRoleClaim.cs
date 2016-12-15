namespace Api.Models.Identity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AspNetRoleClaim
    {
        public int Id { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        [Required]
        [StringLength(450)]
        public string RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual AspNetRole AspNetRole { get; set; }
    }
}
