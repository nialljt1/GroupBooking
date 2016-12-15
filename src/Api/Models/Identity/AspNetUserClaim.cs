namespace Api.Models.Identity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AspNetUserClaim
    {
        public int Id { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        [Required]
        [StringLength(450)]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
