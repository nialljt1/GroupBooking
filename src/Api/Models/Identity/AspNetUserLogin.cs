namespace Api.Models.Identity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AspNetUserLogin
    {
        [Column(Order = 0)]
        [StringLength(450)]
        public string LoginProvider { get; set; }

        [Column(Order = 1)]
        [StringLength(450)]
        public string ProviderKey { get; set; }

        public string ProviderDisplayName { get; set; }

        [Required]
        [StringLength(450)]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
