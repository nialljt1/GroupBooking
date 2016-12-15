namespace Api.Models.Identity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class AspNetRole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AspNetRole()
        {
            AspNetRoleClaims = new HashSet<AspNetRoleClaim>();
            AspNetUsers = new HashSet<AspNetUser>();
        }

        [StringLength(450)]
        public string Id { get; set; }

        public string ConcurrencyStamp { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(256)]
        public string NormalizedName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
